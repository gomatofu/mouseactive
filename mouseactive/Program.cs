using System;
using System.Timers;
using System.Runtime.InteropServices;

namespace mouseactive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 座標
            int x = 0;
            int y = 0;     
            int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int wideth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

            // コンソール出力
            Console.WriteLine("Do you move this mouse?");
            Console.ReadLine();

            // 開始時に間隔を指定する
            var timer = new Timer(1/*msec*/);

            // Elapsedイベントにタイマー発生時の処理を設定する
            timer.Elapsed += (sender, e) =>
            {
                if(x == wideth && !(y == height))
                {
                    y++;
                }
                else if(y == height && !(x == 0))
                {
                    x--;
                }
                else if(y == 0)
                {
                    x++;
                }
                else 
                {
                    y--;
                }
                // マウス移動
                NativeMethods.SetCursorPos(x, y);

            };

            // タイマーを開始する
            timer.Start();

            Console.ReadLine();

            // タイマーを停止する
            timer.Stop();

            // 資源の解放
            using (timer) { }
        }
    }

    /// <summary>
    /// マウス移動メソッド
    /// </summary>
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
    }

}
