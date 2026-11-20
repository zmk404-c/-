using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 贪吃蛇
{
    public partial class Form1 : Form
    {
         
        //写一个刷新面板的函数
        private void shuaxing()
        {
             //初始化变量
            this.Controls.Clear();
            int x, y;
            x = y = 0;

            //释放
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = this.Controls[i];
                if (ctrl is System.Windows.Forms.Label)  
                {
                    this.Controls.RemoveAt(i);  
                    ctrl.Dispose();             
                }
            }

            //历遍map的所有数据

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int b=0; b < map.GetLength(1); b++)
                {
                    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();

                    lbl.AutoSize = true;
                    lbl.Font = new Font("微软雅黑", 16);
                    lbl.Text = map[i, b];
                    lbl.Location = new Point(x, y);

                    this.Controls.Add(lbl);

                    // 每次向右移动 30 像素
                    x = x + 30;
                }
                y = y + 30;
                x = 0;
            }
        }
        //创建一个初始地图
        static string[,] map = new string[10, 10]
        {
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        {  "0","0","0","0","0","0","0","0","0","0", },
        };
        public Form1()
        {
            InitializeComponent();
        }
        //一些前端
        private async void Form1_Load(object sender, EventArgs e)
        {
            //一些优化体验的设置
            this.Size = new Size(320, 340);
            this.MinimumSize = new Size(320, 340);
            this.StartPosition = FormStartPosition.CenterScreen;
            int y=0,x=0;
            //绘制代码
            while (1 > 0)
            { 
                shuaxing();   //绘制
                await Task.Delay(500);  //等待0.5秒
                map[y, x] = "1";  
                x = x + 1;
                if (x > 9) 
                {
                    y = y + 1;
                    x = 0;
                }
            }
        }
    }
}
