using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCCM_Query_Creator
{
    public partial class Form1 : Form
    {
        AboutBox1 fmr2;
        //readonly List<string> items = new List<string> { "cat", "carrot", "dog", "goat", "pig" };
        List<string> MyList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }


        

        private void button6_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                Clipboard.SetText(textBox3.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String myText = Clipboard.GetText();
            textBox1.Text = myText;
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string colours = textBox1.Text;
            char separator = new char();
            if (!String.IsNullOrEmpty(colours))
            {
                if (radioButton1.Checked)
                {
                    separator = ';';
                }
                else if (radioButton2.Checked)
                {
                    separator = ',';
                }
                else if (radioButton3.Checked)
                {
                    if (String.IsNullOrEmpty(textBox2.Text))
                    {
                        toolStripStatusLabel1.Text = "Please input a string separator";
                        toolStripStatusLabel1.BackColor = Color.Red;
                        toolStripStatusLabel1.ForeColor = Color.White;
                    }
                    else
                    {
                        char character = char.Parse(textBox2.Text);
                        separator = character;
                    }
                }

                if (separator != '\0')
                {
                    string res = string.Join(Environment.NewLine, colours.Split(separator));
                    textBox3.Text = res;
                    toolStripStatusLabel1.Text = "Converted";
                    toolStripStatusLabel1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.White;
                }
            }
            else 
            {
                toolStripStatusLabel1.Text = "Please input a string to convert";
                toolStripStatusLabel1.BackColor = Color.Red;
                toolStripStatusLabel1.ForeColor = Color.White;
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String myText = Clipboard.GetText();
            textBox4.Text = myText;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Text = String.Empty;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox6.Text))
            {
                Clipboard.SetText(textBox6.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox7.Text))
            {
                Clipboard.SetText(textBox7.Text);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox8.Text))
            {
                Clipboard.SetText(textBox8.Text);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrEmpty(textBox4.Text)) && (!String.IsNullOrEmpty(textBox15.Text))) {

                textBox6.Text = "";
                textBox6.Enabled = false;
                textBox7.Text = "";
                textBox7.Enabled = false;
                textBox8.Text = "";
                textBox8.Enabled = false;
                textBox11.Text = "";
                textBox11.Enabled = false;
                textBox10.Text = "";
                textBox10.Enabled = false;
                textBox9.Text = "";
                textBox9.Enabled = false;
                textBox14.Text = "";
                textBox14.Enabled = false;
                textBox13.Text = "";
                textBox13.Enabled = false;
                textBox12.Text = "";
                textBox12.Enabled = false;


                string text = textBox4.Text;
                int mylenght = Int32.Parse(textBox15.Text);
                string[] stringArray = new string[] { text };
                string startstring = "";
                string computers = "select distinct SMS_R_System.ResourceId, SMS_R_System.ResourceType, SMS_R_System.Name, SMS_R_System.SMSUniqueIdentifier, SMS_R_System.ResourceDomainORWorkgroup, SMS_R_System.Client from SMS_R_System where SMS_R_System.Name in";
                string users = "select * from SMS_R_User where name in";


                if (radioButton4.Checked) 
                {
                    startstring = computers;
                }
                if (radioButton5.Checked) 
                {
                    startstring = users;
                }

                List<string> s = GetStringSegments(text, mylenght);
                if (s.ElementAtOrDefault(0) != null) 
                {
                    string myString = s[0].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    
                    myString = startstring + @"(""" + myString + @""")";
                    textBox6.Text = myString;
                    textBox6.Enabled = true;
                }
                if (s.ElementAtOrDefault(1) != null)
                {
                    string myString = s[1].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    // myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox7.Text = myString;
                    textBox7.Enabled = true;
                }
                if (s.ElementAtOrDefault(2) != null)
                {
                    string myString = s[2].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    //myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox8.Text = myString;
                    textBox8.Enabled = true;
                }

                if (s.ElementAtOrDefault(3) != null)
                {
                    string myString = s[3].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    // myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox11.Text = myString;
                    textBox11.Enabled = true;
                }

                if (s.ElementAtOrDefault(4) != null)
                {
                    string myString = s[4].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    // myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox10.Text = myString;
                    textBox10.Enabled = true;
                }

                if (s.ElementAtOrDefault(5) != null)
                {
                    string myString = s[5].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    // myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox9.Text = myString;
                    textBox9.Enabled = true;
                }

                if (s.ElementAtOrDefault(6) != null)
                {
                    string myString = s[6].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    // myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox14.Text = myString;
                    textBox14.Enabled = true;
                }

                if (s.ElementAtOrDefault(7) != null)
                {
                    string myString = s[7].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    // myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox13.Text = myString;
                    textBox13.Enabled = true;
                }

                if (s.ElementAtOrDefault(8) != null)
                {
                    string myString = s[8].Replace(System.Environment.NewLine, @""",""");
                    string res = myString.GetLast(3);
                    if (res == @""",""") { myString = myString.Substring(0, myString.Length - 3); }
                    // myString = myString.Substring(0, myString.Length - 2);
                    myString = startstring + @"(""" + myString + @""")";
                    textBox12.Text = myString;
                    textBox12.Enabled = true;
                }

                toolStripStatusLabel1.Text = "Converted";
                toolStripStatusLabel1.BackColor = Color.Green;
                toolStripStatusLabel1.ForeColor = Color.White;

            }
            else
            {
                toolStripStatusLabel1.Text = "Please input a string and split number";
                toolStripStatusLabel1.BackColor = Color.Red;
                toolStripStatusLabel1.ForeColor = Color.White;
            }
           
        }

        public static List<string> GetStringSegments(string original, int linesPerSegment)
        {
            List<string> segments = new List<string>();

            int startIndex = 0;
            int newLinesEncountered = 0;

            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == '\n')
                {
                    newLinesEncountered++;
                }

                if (newLinesEncountered == linesPerSegment
                    || i == original.Length - 1)
                {
                    segments.Add(original.Substring(startIndex, (i - startIndex + 1)));
                    startIndex = i + 1;
                    newLinesEncountered = 0;
                }
            }

            return segments;
        }
        private void textBox4_Click(object sender, EventArgs e) {
            int line = textBox4.GetLineFromCharIndex(textBox4.SelectionStart);
            int trueline = line + 1;
            int column = textBox4.SelectionStart - textBox4.GetFirstCharIndexFromLine(line);
            int truecolumn = column + 1;
            label2.Text = trueline.ToString();
            label4.Text = truecolumn.ToString();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int line = textBox4.GetLineFromCharIndex(textBox4.SelectionStart);
            int trueline = line + 1;
            int column = textBox4.SelectionStart - textBox4.GetFirstCharIndexFromLine(line);
            int truecolumn = column + 1;
            label2.Text = trueline.ToString();
            label4.Text = truecolumn.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int trueline = line + 1;
            int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
            int truecolumn = column + 1;
            label7.Text = trueline.ToString();
            label9.Text = truecolumn.ToString();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int trueline = line + 1;
            int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
            int truecolumn = column + 1;
            label7.Text = trueline.ToString();
            label9.Text = truecolumn.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int line = textBox3.GetLineFromCharIndex(textBox3.SelectionStart);
            int trueline = line + 1;
            int column = textBox3.SelectionStart - textBox3.GetFirstCharIndexFromLine(line);
            int truecolumn = column + 1;
            label12.Text = trueline.ToString();
            label11.Text = truecolumn.ToString();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            int line = textBox3.GetLineFromCharIndex(textBox3.SelectionStart);
            int trueline = line + 1;
            int column = textBox3.SelectionStart - textBox3.GetFirstCharIndexFromLine(line);
            int truecolumn = column + 1;
            label12.Text = trueline.ToString();
            label11.Text = truecolumn.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            string datafromfile = Properties.Resources.data;
            List<string> MyList2 = new List<string>();

            string[] lines = datafromfile.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                MyList2.Add(line);
            }
            listBox1.Items.Clear();

            foreach (string str in MyList2)
            {
                if (str.ToUpper().Contains(textBox16.Text.ToUpper()))
                {
                    listBox1.Items.Add(str);
                }
            }

            double total = listBox1.Items.Count;
            label16.Text = total.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            string text2 = "SCCM_Query_Creator.Resources." + text + ".txt";
            string rezultat = ReadTextResourceFromAssembly(text2);
            textBox17.Text = rezultat;

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            string[] resources = thisExe.GetManifestResourceNames();
            string list = "";

            // Build the string of resources.
            foreach (string resource in resources)
                list += resource + "\r\n";

            //textBox17.Text = list;
        }

        public static string ReadTextResourceFromAssembly(string name)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string datafromfile = Properties.Resources.data;
            List<string> MyList = new List<string>();

            string[] lines = datafromfile.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                MyList.Add(line);
            }
            MyList.Sort();
            listBox1.Items.AddRange(MyList.ToArray());

            double total = MyList.Count;
            label16.Text = total.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox17.Text))
            {
                Clipboard.SetText(textBox17.Text);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }

    public static class StringExtension
    {
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
    }

    public static class Extensions
    {
        public static IEnumerable<string> Split(this string str, int n)
        {
            if (String.IsNullOrEmpty(str) || n < 1)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < str.Length; i += n)
            {
                yield return str.Substring(i, Math.Min(n, str.Length - i));
            }
        }
    }
}
