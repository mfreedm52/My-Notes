using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyNotes
{
    public static class JavascriptActions
    {
       
        public static string SelectBook(int BookId)
        {
            return string.Format("$('.kp-notebook-cover-image-border')[{0}].click()", BookId);
        }

        public static string NoteText(int NotePosition)
        {
           
            return string.Format("$('.kp-notebook-highlight')[{0}].innerText", NotePosition);
        }

        public static string HideHighlight(string color)
        {
            return string.Format("$('.kp-notebook-highlight-{0}').parent().parent().parent().parent().hide()", color);
        }

        public static string ShowHighlight(string color)
        {
            return string.Format("$('.kp-notebook-highlight-{0}').parent().parent().parent().parent().show()", color);
        }

        public static string AddNote(string note)
        {
            return @"$('a#addnote[value=QTE4Qk5EMlJZSFFIN086QjAwRks5MDFSODozNjEzOTpISUdITElHSFQ6YTM4S1dDSTZBUTMxRQ]')[0].click()";
        }


    }
}