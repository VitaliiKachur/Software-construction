using Composite.Composite;
using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composite
{
    internal class Program
    {
        public static async Task ShowImageFromFileAsync(string path)
        {
            await Task.Run(() =>
            {
                Form form = new Form();
                PictureBox pb = new PictureBox
                {
                    Image = Image.FromFile(path),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(pb);
                form.Text = "Локальне зображення";
                form.ClientSize = new Size(600, 400);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            });
        }

        public static async Task ShowImageFromUrlAsync(string url)
        {
            await Task.Run(() =>
            {
                using (var webClient = new WebClient())
                using (var stream = webClient.OpenRead(url))
                {
                    if (stream != null)
                    {
                        Image image = Image.FromStream(stream);

                        Form form = new Form();
                        PictureBox pb = new PictureBox
                        {
                            Image = image,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Dock = DockStyle.Fill
                        };
                        form.Controls.Add(pb);
                        form.Text = "Зображення з мережі";
                        form.ClientSize = new Size(600, 400);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.ShowDialog();
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Не вдалося завантажити зображення з мережі.");
                    }
                }
            });
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var div = new LightElementNode("div", "block");
            div.AddClass("container");

            var p = new LightElementNode("p", "block");
            p.AddClass("text");
            p.AddChild(new LightTextNode("Привіт, це абзац тексту!"));

            var img = new LightElementNode("img", "inline", true);
            img.AddClass("image");

            div.AddChild(p);
            div.AddChild(img);

            var filePath = "D:\\Документи диск D\\Конструювання\\Стратегія\\Composite\\images\\new11.png";
            var url = "https://media.istockphoto.com/id/517188688/ru/%D1%84%D0%BE%D1%82%D0%BE/%D0%B3%D0%BE%D1%80%D0%BD%D1%8B%D0%B9-%D0%BB%D0%B0%D0%BD%D0%B4%D1%88%D0%B0%D1%84%D1%82.jpg?s=1024x1024&w=0&k=20&c=TqKo4rS3By8VfXQlepFRtpjWGdzs6x0DSXkTIBXi_zc=";

            var fileImage = new LightImageNode(filePath, new FileImageLoader());
            var networkImage = new LightImageNode(url, new NetworkImageLoader());

            div.AddChild(fileImage);
            div.AddChild(networkImage);

            Console.WriteLine("InnerHTML:");
            Console.WriteLine(div.InnerHTML);
            Console.WriteLine("\nOuterHTML:");
            Console.WriteLine(div.OuterHTML);

            Console.WriteLine("\n🖼️ Відкриваємо локальне зображення у формі...");
            var fileTask = ShowImageFromFileAsync(filePath);

            Console.WriteLine("\n🌐 Відкриваємо зображення з мережі у формі...");
            var networkTask = ShowImageFromUrlAsync(url);

            await Task.WhenAll(fileTask, networkTask);
        }
    }
}
