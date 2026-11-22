using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
namespace 贪吃蛇
{
    public partial class Form1 : Form
    {

        //写一个刷新面板的函数A
        private void shuaxing()
        {
             //初始化变量
            
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
                    lbl.Text = map[i, b].ToString();
                    lbl.Location = new Point(x, y);
                    this.Controls.Add(lbl);
                    x = x + 30;
                }
                y = y + 30;
                x = 0;
            }
        }
        //写一个辅助计算的函数　   
        private int zuidazhi(int[,] a)
        {
            int zuida = a[0, 0];
            for (int i = 1; i < a.GetLength(0); i++)
            {
                if (a[i, 0] > zuida)
                    zuida = a[i, 0];
            }
            return zuida;
        }
        private void jianyi()
        {
            int a;
            a = zuidazhi(python);
            python[1, a] = 1;
            for (int i = 0; i < python.GetLength(0); i++)
            {
                python[i, 1] = python[i, 1 ] + 1;
            }
            //python[1, a] = 1;
        }
        //写一个前进的函数
        private void Run(int a)
        {
            //判断输入方向 输出代码块
            switch (a)
            {
                case 1:
                    //向前方前进
                    if (x > 8)     
                    {
                        
                        map[y, 0] = '1';
                        x = 0;
                        map[y, 9] = ' ';

                    }
                    else     
                    {
                        x = x + 1;
                        map[y, x] = '1';
                        map[y, x - 1] = ' ';
                    }               
                    break;
                case 2:
                   
                    //向下方前进
                    if (y > 8)
                    {
                        map[0, x] = '1';
                        y = 0;
                        map[9, x] = ' ';
                    }
                    else
                    {
                        y  = y + 1;
                        map[y, x] = '1';
                        map[y - 1, x] = ' ';
                    }
                    break;
                case 3:
                  
                    //向后方前进
                    if (x < 1)
                    {
                        map[y, 9] = '1';
                        x = 9;
                        map[y, 0] = ' ';
                    }
                    else
                    {
                        x = x - 1;
                        map[y, x] = '1';
                        map[y, x + 1] = ' ';
                    }
                    break;
                case 4:
                  
                    //向上方前进
                    if (y < 1)
                    {
                        map[9, x] = '1';
                        y = 9;
                        map[0, x] = ' ';
                    }
                    else
                    {
                        y = y - 1;
                        map[y, x] = '1';
                        map[y + 1, x] = ' ';
                    }
                    break;
            }
        }
        
        //创建一个初始地图
        static char[,] map = new char[10, 10]
        {
        { '1',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' }
        };

        //创建一个注册列表 登记每节身体
        static int[,] python = new int[100, 3]
        {
            {1,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
            {0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },{0,0,0 },
        };
        //创建几个判断变量
        static int y = 0, x = 0; // 用于辅助计算移动
        static int y1, x1;   //用于计算蛇头
        static int ba = 1;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // 允许窗体优先捕获键盘事件
            this.KeyDown += Form1_KeyDown; // 绑定键盘按下事件
        }
        //一些前端
        private async void Form1_Load(object sender, EventArgs e)
        {
            //一些优化体验的设置
            this.Size = new Size(320, 340);
            this.MinimumSize = new Size(320, 340);
            this.StartPosition = FormStartPosition.CenterScreen;
            //创建辅助变量
            char she = ' ';    //用于定位蛇的位置       
            //绘制代码
             while (1 > 0)
             {
                shuaxing();   //绘制
                await Task.Delay(250);  //等待0.25秒
                 
                //这个死妈的逻辑给我看吐了
                int jie = zuidazhi(python);
                y = python[jie, 1];
                x = python[jie, 2];
                Run(ba);
                python[jie, 1] = y;
                python[jie, 2] = x;
                jianyi();
             }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                if (ba != 2)
                {
                    ba = 4; // 向上
                }
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (ba != 4)
                {
                    ba = 2; // 向下
                }
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if (ba != 1)
                {
                    ba = 3; // 向左
                }
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                if (ba != 3)
                {
                    ba = 1; // 向右
                }
            }
        }     
    }
}
