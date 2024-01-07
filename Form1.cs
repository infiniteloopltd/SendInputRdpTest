using Timer = System.Threading.Timer;

namespace SendInputRdpTester
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += (o, args) =>
            {
                textBox1.Focus();
                SendKeys.Send(GetLetter().ToString());
            };
            timer.Start();
        }

        public static char GetLetter()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            return chars[num];
        }
    }
}