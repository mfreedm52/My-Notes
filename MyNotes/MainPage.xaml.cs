using Xamarin.Forms;
using System.Collections.Generic;

namespace MyNotes
{

    public partial class MainPage : ContentPage
	{
        private static int BookCounter = 0;

        private static Dictionary<string, bool> notesFlag = InitializeDict();

        /* new init */
        private static Dictionary<string, bool> InitializeDict()
        {
            notesFlag = new Dictionary<string, bool>();
            notesFlag.Add("yellow", false);
            notesFlag.Add("blue", false);
            notesFlag.Add("pink", false);
            notesFlag.Add("orange", false);
            return notesFlag;
        }

        public MainPage(MyNotes.DeviceDetails device, CookieWebView web)
		{
            InitializeComponent();

            WebContentLayout.Children.Add(web);
            btnYellow.Pressed += (sender, e) => ShowHideNote("yellow", web);
            btnBlue.Pressed += (sender, e) => ShowHideNote("blue", web);
            
            BookCounter = 0;

        }

        public void ShowHideNote(string noteColor, CookieWebView web)
        {
            if (notesFlag[noteColor])
            {
                web.Eval(JavascriptActions.ShowHighlight(noteColor));
                notesFlag[noteColor] = false;
            }
            else
            {
                web.Eval(JavascriptActions.HideHighlight(noteColor));
                notesFlag[noteColor] = true;

            }

        }

	}
}
