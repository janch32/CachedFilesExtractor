using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace CachedFilesExtractor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string ChromeUserDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\\Chrome\\User Data");
        string[] SourceFiles = null;
        int SourceFilesIndex = 0;
        Dictionary<string, int> ParsedFormats = null;


		void LoadChromeProfiles()
		{
			ProfileSelect.Items.Clear();

			foreach (string folders in Directory.GetDirectories(ChromeUserDataPath))
			{
				if (Directory.Exists(Path.Combine(folders, "Cache")))
				{
					ProfileSelect.Items.Add(Path.GetFileName(folders));
				}
			}

			ProfileSelect.SelectedIndex = 0;
		}

        static ImageFormat FileTryGetImageFormat(string filename)
        {
            try
            {
                var img = Image.FromFile(filename);
                var format = img.RawFormat;
                img.Dispose();
                return format;
            }
            catch (Exception)
            {
                return null;
            }
        }

		void AllFilesLoaded()
		{
			Invoke(new Action(() => {
				ProfileSelect.Enabled = true;
				SaveButton.Enabled = true;
			}));
		}

		void InvalidateStats()
		{
			Invoke(new Action(() => {
				Stats.Invalidate();
			}));
		}

        static ImageFormatConverter FormatConverter = new ImageFormatConverter();

        private void GetFilesFromCache()
        {
			try
            {
			    string OutputFolder = "Záloha cache - " + SelectedProfile + " (" + DateTime.Now.ToFileTime() + ")";
                SourceFiles = Directory.GetFiles(Path.Combine(ChromeUserDataPath, SelectedProfile, "Cache"));
                ParsedFormats = new Dictionary<string, int>();

                Directory.CreateDirectory(OutputFolder);

                for (SourceFilesIndex = 0; SourceFilesIndex < SourceFiles.Length; SourceFilesIndex++)
                {
                    string SourcePath = SourceFiles[SourceFilesIndex];
                    var Format = FileTryGetImageFormat(SourcePath);

                    if (Format != null)
                    {
                        string FormatExtension = FormatConverter.ConvertToString(Format).ToLower();

                        string OutputFilename = "Obrázek " + ParsedFormats.Values.Sum() + "." + FormatExtension;
                        File.Copy(SourcePath, Path.Combine(OutputFolder, OutputFilename));

                        if (!ParsedFormats.ContainsKey(FormatExtension))
                            ParsedFormats.Add(FormatExtension, 0);

                        ParsedFormats[FormatExtension]++;
                    }

                    InvalidateStats();
                }
            }
            catch (Exception) {
                // chyba při IO přístupu
            }

            AllFilesLoaded();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
			ProfileSelect.Enabled = false;
			SaveButton.Enabled = false;
            
			Thread t = new Thread(new ThreadStart(GetFilesFromCache));
            t.Start();
        }

        private static Brush GetBrushByFormat(string format)
        {
            if (format.Equals("bmp")) return Brushes.Blue;
            if (format.Equals("emf")) return Brushes.Red;
            if (format.Equals("exif")) return Brushes.Green;
            if (format.Equals("gif")) return Brushes.Orange;
            if (format.Equals("ico")) return Brushes.Purple;
            if (format.Equals("jpeg")) return Brushes.Pink;
            if (format.Equals("png")) return Brushes.LimeGreen;
            if (format.Equals("tiff")) return Brushes.Azure;
            if (format.Equals("wmf")) return Brushes.Brown;
            return Brushes.Gray;
        }

        private void DrawStats(object sender, PaintEventArgs e)
        {
            Control c = (Control) sender;
            Graphics g = e.Graphics;
            int center = (c.Width - 150) / 2;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillPie(Brushes.WhiteSmoke, center, 6, 150, 150, -90, 360);

            if (SourceFiles == null || SourceFiles.Length == 0 || ParsedFormats == null) return;
            float progress = (float)(SourceFilesIndex + 1) / SourceFiles.Length;

            g.FillPie(Brushes.LightGray, center, 6, 150, 150, -90, progress * 360);
                
            if (ParsedFormats.Values.Count > 0)
            {
                float celkem = -90;
                foreach (var f in ParsedFormats.Keys)
                {
                    float angle = (float)ParsedFormats[f] / SourceFiles.Length * 360;
                    g.FillPie(GetBrushByFormat(f), center, 0, 150, 150, celkem, angle);
                    celkem += angle;
                }
            }

            // Legenda 


            g.FillRectangle(Brushes.LightGray, 20, c.Height - DefaultFont.Height, 10, 10);
            g.DrawString((SourceFilesIndex + 1) + " prohledaných souborů", DefaultFont, Brushes.Black, 40, c.Height - DefaultFont.Height);

            int i = 1;
            foreach (var f in ParsedFormats.Keys)
            {
                i++;
                g.FillRectangle(GetBrushByFormat(f), 20, c.Height - i * DefaultFont.Height, 10, 10);
                g.DrawString(ParsedFormats[f] + " " + f + " obrázků", DefaultFont, Brushes.Black, 40, c.Height - i * DefaultFont.Height);
            }
        }

        private void WindowLoad(object sender, EventArgs e)
        {
            LoadChromeProfiles();
            if (ProfileSelect.Items.Count < 1)
            {
                MessageBox.Show("Žádné profily prohlížeče Google Chrome nenalezeny", "CacheToFile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        string SelectedProfile = "";
        private void ProfileSelectChange(object sender, EventArgs e)
        {
            SelectedProfile = (string)((ComboBox)sender).SelectedItem;
        }
    }
}
