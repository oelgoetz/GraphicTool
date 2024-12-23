﻿using GraphicTool.Properties;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using txtFiles;
using static System.Net.Mime.MediaTypeNames;

namespace GraphicTool
{
    public partial class DevTool01 : Form
    {
        Form1 parent;
        bool TEST = true;
        public DevTool01(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            if (TEST) label1.Text = "TEST"; else label1.Text = "!ACTIVE!";
        }

        private void searchByXPath(string XPath, bool vals)
        {
            //Pfeilfehler:
            //Shape[@Type='Polyline' and @ArrowHeadCenterLength and not(@ArrowHeadLength ) and not(@ArrowHeadWidth )]
            //Shape[@Type='Polyline' and @ArrowHeadLength and not(@ArrowHeadCenterLength)]
            Cursor = Cursors.WaitCursor;
            lBHitFiles.Items.Clear();
            bool error = false;
            XmlDocument file = new XmlDocument();
            XmlDocument ActionDoc = new XmlDocument();
            int nodeCount = 0;
            List<string> hitFiles = new List<string>();
            List<string> checkedFiles = new List<string>();
            List<string> attributes = new List<string>();

            if (vals)
            {
                string[] temp = XPath.Split('@');
                foreach (string p in temp)
                {
                    if (p.Contains("=")) continue;
                    if (p.Trim().EndsWith("]"))
                    {
                        string p1 = p.Trim().TrimEnd(']');
                        attributes.Add(p1);
                    }
                }
            }

            Dictionary<string, int> vc = new Dictionary<string, int>();

            foreach (string ActionFile in lBActionFiles.Items) //Loop 1: Pick ActionFiles
            {
                ActionDoc.Load(ActionFile);
                XmlNodeList hits = ActionDoc.SelectNodes("//File[@FileType=\"ImageProperties\"]");

                foreach (XmlNode hit in hits) //Loop 2: Pick all props files from ActionFiles
                {
                    string fileName = hit.ParentNode.Attributes["Path"].Value + hit.Attributes["ID"].Value;
                    if (File.Exists(fileName) && error == false)
                    {
                        if (!checkedFiles.Contains(fileName))
                        {
                            file.Load(fileName);
                            XmlNodeList nodes = null;
                            try
                            {
                                nodes = file.SelectNodes(XPath); //Apply Xpath to props files 
                                nodeCount += nodes.Count;
                                if (nodes.Count > 0)
                                {
                                    hitFiles.Add(fileName);
                                    lBHitFiles.Items.Add(nodes.Count.ToString() + " " + fileName);
                                    if (vals)
                                    {
                                        foreach (XmlNode node in nodes)
                                        {
                                            string attribute = attributes[0];
                                            string val = node.Attributes[attribute].Value.ToLower();
                                            if (!vc.ContainsKey(val)) vc.Add(val, 1); else vc[val]++;
                                        }
                                    }
                                }
                                checkedFiles.Add(fileName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, fileName);
                                Clipboard.SetText(ex.Message);
                                error = true;
                                break;
                            }
                            checkedFiles.Add(fileName);
                        }
                    }
                }
            }
            if (!error) updateRecentXPaths(XPath);
            statusStrip1.Items[0].Text = hitFiles.Count.ToString();
            if (vc.Count > 0)
            {
                lBHitFiles.Items.Add("-----");

                //https://stackoverflow.com/questions/289/how-do-you-sort-a-dictionary-by-value
                var myList = vc.ToList();
                myList.Sort((x, y) => y.Value.CompareTo(x.Value));
                string s = "";
                foreach (var item in myList)
                {
                    lBHitFiles.Items.Add(item.Key + ";" + item.Value.ToString());
                    s += item.Key + ";" + item.Value.ToString() + "\r\n";
                }
            }
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchByXPath(comboBox1.Text, cBValues.Checked);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = lBHitFiles.SelectedItem.ToString();
            Clipboard.SetText(fileName);
            fileName = fileName.Substring(fileName.IndexOf(" ") + 1);
            try
            {
                parent.LoadFile(fileName, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, fileName);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string[] repos = {/* @"C:\docuR2022", *//*@"C:\docuR202301", @"C:\docuR202302",*/ @"C:\docuR202401" };
            string[] langs = { @"00", @"01"/*, @"02", @"03", @"17"*/ };
            string[] actionFiles = { "ActionsGLHelp.xml"/*, "ActionsV4Help.xml"*/ };
            List<string> projects = new List<string>();
            projects.Add(@"TMSGL");
            projects.Add(@"TDMGL");
            //string[] keys = { "GL8cb170f2_fd17_4279_943b_2159ed97924c-Plant Allocation",
            //                    "GL59906026_37bd_4a19_b4bf_338e80c92ed1-Machine Allocation",
            //                    "GLc63cfc66_cfec_45b8_92b7_7a44a84001fc-Stock Locations",
            //                    "GL1199a7a2_c06d_4e3d_a7b8_0fa439087b2c-Allocated Cost Centers" };

            lBHitFiles.Items.Clear();

            foreach (string repo in repos)
            {
                foreach (string lan in langs)
                {
                    foreach (string actionFile in actionFiles)
                    {
                        if (!File.Exists(repo + "\\" + lan + "\\" + actionFile))
                        {
                            continue;
                        }
                        XmlDocument ActionDoc = new XmlDocument();
                        try
                        {
                            ActionDoc.Load(repo + "\\" + lan + "\\" + actionFile);
                        }
                        catch
                        {
                            continue;
                        }

                        XmlNodeList Projects = ActionDoc.SelectNodes("//Project");
                        bool stdout = true;
                        //foreach (string project in projects)
                        foreach (XmlNode Project in Projects)
                        {

                            string project = Project.Attributes["Token"].Value;
                            string message = repo + "\\" + lan + "\\" + project;
                            //listBox1.Items.Add(message);
                            string aliasFile = message + "\\Project\\Advanced\\" + project.ToLower() + "alias.flali";
                            if (!File.Exists(aliasFile))
                                aliasFile = message + "\\Project\\Advanced\\CSH\\" + project.ToLower() + "alias.flali";
                            if (File.Exists(aliasFile))
                            {
                                XmlDocument aliasDoc = new XmlDocument();
                                aliasDoc.Load(aliasFile);

                                List<string> keys = new List<string>();
                                foreach (XmlNode node in aliasDoc.DocumentElement.ChildNodes)
                                {
                                    if (node.Attributes["Name"] != null)
                                    {
                                        if (!keys.Contains(node.Attributes["Name"].Value))
                                            keys.Add(node.Attributes["Name"].Value);
                                        else
                                        {
                                            //listBox1.Items.Add(aliasFile + ": double usage of key " + node.Attributes["Name"].Value);
                                        }
                                    }
                                }
                                foreach (string k in keys)
                                {
                                    string key = k;
                                    if (k.Contains(" - "))
                                        key = k.Substring(0, k.IndexOf('-'));
                                    XmlNode Map = aliasDoc.SelectSingleNode("//Map[@Name='" + key + "']");
                                    if (Map != null)
                                    {
                                        string targetTopic = "";
                                        string bookmark = "";
                                        string[] temp = null;
                                        string targetTopicAndBookmark = Map.Attributes["Link"].Value.Replace("/", "\\");
                                        if (targetTopicAndBookmark.Contains('#'))
                                        {
                                            temp = targetTopicAndBookmark.Split('#');
                                            if (temp.Length > 2)
                                            {
                                                string v = Map.Attributes["Link"].Value;
                                                v = v.Substring(0, v.LastIndexOf("#"));
                                                Map.Attributes["Link"].Value = v;
                                                lBHitFiles.Items.Add(Map.Attributes["Link"].Value);
                                                //aliasDoc.Save(aliasFile);
                                                targetTopicAndBookmark = Map.Attributes["Link"].Value.Replace("/", "\\");
                                                temp = targetTopicAndBookmark.Split('#');
                                            }
                                            if (temp.Length == 1)
                                            {
                                                targetTopic = message + targetTopicAndBookmark;
                                                //listBox1.Items.Add(message + " > " + targetTopic);
                                            }
                                            if (temp.Length == 2)
                                            {
                                                if (temp[0] == "")
                                                    continue;
                                                targetTopic = message + temp[0];
                                                bookmark = temp[1];
                                                //listBox1.Items.Add(targetTopic + " > " + bookmark);
                                            }

                                        }
                                        else
                                            targetTopic = message + targetTopicAndBookmark;
                                        if (File.Exists(targetTopic))
                                        {
                                            if (bookmark != "")
                                            {
                                                XmlDocument targetDoc = new XmlDocument();
                                                targetDoc.Load(targetTopic);

                                                XmlNode bookmarkTarget = targetDoc.SelectSingleNode("//a[@name='" + bookmark + "']");
                                                if (bookmarkTarget != null)
                                                {
                                                    //listBox1.Items.Add("File: OK, bookmark: OK " + message);
                                                }
                                                else
                                                {
                                                    string v = Map.Attributes["Link"].Value;
                                                    string[] t1 = v.Split('#');
                                                    string v1 = t1[0];// + '#' + t1[1];
                                                    Map.Attributes["Link"].Value = v1;
                                                    if (!TEST) aliasDoc.Save(aliasFile);
                                                    if (stdout) lBHitFiles.Items.Add("File: OK, bookmark not found: " + message + ' ' + targetTopic + '#' + bookmark);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (targetTopic == "")
                                            {
                                                //Clipboard.SetText(aliasFile + " " + Map.Attributes["Link"].Value + " " + Map.Attributes["Name"].Value);
                                                //MessageBox.Show(aliasFile + " " + Map.Attributes["Link"].Value + " " + Map.Attributes["Name"].Value);
                                            }
                                            if (stdout) lBHitFiles.Items.Add("File not found! " + project + ": " + targetTopic);
                                            //listBox1.Items.Add(message);
                                        }
                                        //listBox1.Items.Add(message);
                                        //Nach dem ersten Durchlauf egal:
                                        //if (temp.Length > 2)
                                        //{
                                        //    targetTopic = temp[0] + repo + lan + project + targetTopic;
                                        //    bookmark = temp[1];

                                        //    string v = Map.Attributes["Link"].Value;
                                        //    string[] t1 = v.Split('#');
                                        //    string v1 = t1[0] + '#' + t1[1];
                                        //    Map.Attributes["Link"].Value = v1;
                                        //    if (!TEST) aliasDoc.Save(aliasFile);

                                        //    message += " !! " + v1;
                                        //}
                                    }
                                    else
                                    {
                                        //listBox1.Items.Add(repo + " " + lan + " " + project + " - " + key + " not found.");
                                    }

                                }
                            }
                            else
                            {
                                //listBox1.Items.Add("No alias file found: " + aliasFile);
                            }
                        }
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        ///--------------------

        int NUMBEROFRECENTXPATHS = 20;

        public void AddXPathToComboBox(string xPath)
        {
            if (!comboBox1.Items.Contains(xPath))
                comboBox1.Items.Add(xPath);
        }

        private void updateRecentXPaths(string xPath)
        {
            int index = -1;
            int i = 0;
            while (i < comboBox1.Items.Count)
            {
                if (comboBox1.Items[i].ToString().ToLower() == xPath.ToLower())
                {
                    index = i;
                    break;
                }
                i++;
            }
            if (comboBox1.Items.Contains(xPath)) return;
            if (index > -1)
            {
                for (int j = index; j > 0; j--)
                {
                    comboBox1.Items[j] = comboBox1.Items[j - 1];
                }
                comboBox1.Items[0] = xPath;
            }
            else
            {
                if (comboBox1.Items.Count < NUMBEROFRECENTXPATHS)
                {
                    AddXPathToComboBox(xPath);
                }
                else
                {
                    for (int j = NUMBEROFRECENTXPATHS - 1; j >= 1; j--)
                    {
                        comboBox1.Items[j] = comboBox1.Items[j - 1];
                    }
                    comboBox1.Items[0] = xPath;
                }
            }
            comboBox1.Text = xPath;
            string t = "";
            foreach (string item in comboBox1.Items)
                t = item + ";" + t;
            GraphicTool.Properties.Settings.Default.RECENTXPATHS = t;
            GraphicTool.Properties.Settings.Default.Save();
        }

        private void loadRECENTXPATHS()
        {
            if (GraphicTool.Properties.Settings.Default.RECENTXPATHS.Length > 0)
            {
                string[] temp = GraphicTool.Properties.Settings.Default.RECENTXPATHS.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Length > 0)
                        AddXPathToComboBox(temp[i]);
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
        }

        private void DevTool01_Load(object sender, EventArgs e)
        {
            loadRECENTXPATHS();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hier.");
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboBox1.DroppedDown && e.KeyCode == Keys.Delete)
            {
                string buffer = comboBox1.Text;
                if (comboBox1.Items.Count == 1)  // Removing Last Item
                {
                    comboBox1.DroppedDown = false;
                    comboBox1.Text = string.Empty;
                    comboBox1.Items.Clear();
                }
                else
                {
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                    comboBox1.Text = buffer;

                    string t = "";
                    foreach (string item in comboBox1.Items)
                    {
                        if (item.Length > 0)
                            t = item + ";" + t;
                    }
                    GraphicTool.Properties.Settings.Default.RECENTXPATHS = t;
                    GraphicTool.Properties.Settings.Default.Save();
                }
                e.Handled = true;
            }
        }

        private void getAllpropsAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //1 C:\docur202401\00\Main\Content\Resources\Images\general\glPrintExampleThumbnailView.png.props
            List<string> attributes = new List<string>();
            List<int> count = new List<int>();
            foreach (string item in lBHitFiles.Items)
            {
                string propsfileName = item.ToString();
                propsfileName = propsfileName.Substring(propsfileName.IndexOf(" ") + 1);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(propsfileName);
                XmlNodeList shapes = xmlDoc.SelectNodes("//Shape");
                foreach (XmlNode shape in shapes)
                {
                    for (int i = 0; i < shape.Attributes.Count; i++)
                    {
                        if (!attributes.Contains(shape.Attributes[i].Name))
                        {
                            attributes.Add(shape.Attributes[i].Name);
                            count.Add(1);
                        }
                        else
                            count[attributes.IndexOf(shape.Attributes[i].Name)] += 1;
                    }
                }

                //MessageBox.Show(propsfileName);
            }
            string s = "";
            for (int j = 0; j < attributes.Count; j++)
            {
                lBHitFiles.Items.Add(count[j].ToString() + " :" + attributes[j]);
                s += count[j].ToString() + " :" + attributes[j] + "\n";
            }
            Cursor.Current = Cursors.Default;
            Clipboard.SetText(s);
        }

        private void getAttributes049ValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextDatei textFile = new TextDatei();
            string filename = @"D:\Resourcen\_CSharp\DisplayDev04\Attributes.csv";
            Cursor = Cursors.WaitCursor;
            lBHitFiles.Items.Clear();
            bool error = false;
            XmlDocument file = new XmlDocument();
            XmlDocument ActionDoc = new XmlDocument();
            int nodeCount = 0;
            List<string> hitFiles = new List<string>();
            List<string> checkedFiles = new List<string>();
            string x = "";
            for (int i = 1; i < 48; i++)
            {
                List<string> values = new List<string>();
                int count = 0;
                string attributeName = textFile.ReadLine(filename, i);
                attributeName = attributeName.Substring(attributeName.IndexOf(";") + 1);
                //listBox1.Items.Add(attributeName);
                foreach (string ActionFile in lBActionFiles.Items)
                {
                    ActionDoc.Load(ActionFile);
                    XmlNodeList hits = ActionDoc.SelectNodes("//File[@FileType=\"ImageProperties\"]");

                    foreach (XmlNode hit in hits)
                    {
                        string fileName = hit.ParentNode.Attributes["Path"].Value + hit.Attributes["ID"].Value;
                        if (File.Exists(fileName) && error == false)
                        {
                            if (!checkedFiles.Contains(fileName))
                            {
                                file.Load(fileName);
                                XmlNodeList nodes = file.SelectNodes("//*[@" + attributeName + "]");
                                foreach (XmlNode node in nodes)
                                {
                                    if (!values.Contains(node.Attributes[attributeName].Value))
                                    {
                                        values.Add(node.Attributes[attributeName].Value);
                                    }
                                }
                                count++;
                                //if(count % 100 == 0)
                                //{
                                //    listBox1.Items.Add(attributeName + ". " + count.ToString() + ": " + values.Count.ToString());
                                //    listBox1.Update();
                                //}

                            }
                        }
                    }
                }
                string s = attributeName;
                values.Sort();
                foreach (string value in values)
                    s = s + ";" + value;
                lBHitFiles.Items.Add(s);
                x = x + s + "\n";
                lBHitFiles.Update();
            }
            Clipboard.SetText(x);
        }

        private void saveListToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            foreach(string line in lBHitFiles.Items) 
            {
                if (line.Contains(" "))
                    s += line.Substring(line.IndexOf(' ')) + "\n";
                else
                    s += line + "\n";
            }
            Clipboard.SetText(s);
        }
    }
}