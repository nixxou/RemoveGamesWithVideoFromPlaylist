using System.Drawing;
using Unbroken.LaunchBox.Plugins;



namespace RemoveGamesWithVideoFromPlaylist
{
	public class MHLConfig : ISystemMenuItemPlugin
	{

		public string Caption
		{
			get
			{
				return "RemoveGamesWithVideoFromPlaylist Configuration";
			}
		}

		public System.Drawing.Image IconImage
		{
			get
			{
				return SystemIcons.Exclamation.ToBitmap();
			}
		}

		public bool ShowInLaunchBox
		{
			get
			{
				return true;
			}
		}


		public bool ShowInBigBox
		{
			get
			{
				return false;
			}
		}


		public bool AllowInBigBoxWhenLocked
		{
			get
			{
				return false;
			}
		}

		public void OnSelected()
		{
			var x = new Form_Config();
			x.ShowDialog();

		}
	}
}
