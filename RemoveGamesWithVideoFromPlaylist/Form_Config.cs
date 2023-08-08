using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;

namespace RemoveGamesWithVideoFromPlaylist
{
	public partial class Form_Config : Form
	{
		private List<Unbroken.LaunchBox.Plugins.Data.IPlaylist> Playlist;
		public Form_Config()
		{
			InitializeComponent();
			Playlist = PluginHelper.DataManager.GetAllPlaylists().Where(p => p.AutoPopulate == false).OrderBy(p => p.Name).ToList();
			foreach (var p in Playlist)
			{
				comboBox1.Items.Add(p.Name);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var ListGameToRemove = new List<Unbroken.LaunchBox.Plugins.Data.IPlaylistGame>();
			if (String.IsNullOrEmpty(comboBox1.Text)) return;
			foreach (var p in Playlist)
			{
				if(p.Name == comboBox1.Text)
				{
					foreach(Unbroken.LaunchBox.Plugins.Data.IPlaylistGame pg in p.GetAllPlaylistGames())
					{
						var g = pg.GetActualGame();
						var videos = g.GetVideoPath();
						if(videos != null && videos.Count() > 0)
						{
							ListGameToRemove.Add(pg);
						}

					}
					foreach(var gameToRemove in ListGameToRemove)
					{
						try
						{
							p.TryRemovePlaylistGame(gameToRemove);
							
						}
						catch { }
					}
					MessageBox.Show($"Removed {ListGameToRemove.Count()} games from playlist");
				}
			}
		}
	}
}
