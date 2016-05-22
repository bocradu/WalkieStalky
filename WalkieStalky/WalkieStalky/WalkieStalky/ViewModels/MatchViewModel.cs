using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageCircle.Forms.Plugin.Abstractions;
using WalkieStalky.Model;
using Xamarin.Forms;

namespace WalkieStalky.ViewModels
{
    public class MatchViewModel:BaseViewModel
    {

        public ImageSource DummyImage{ get; set; }
        public string DummyTopic { get; set; }
        public string DummyUser { get; set; }

        public MatchViewModel(PersonRecord match, string matchedTopicName):this()
        {
            
        }
        public MatchViewModel()
        {
            DummyImage =
                ImageSource.FromUri(
                    new Uri("http://reactiongifs.me/wp-content/uploads/2014/10/tyrion-lannister-eyebrows-game-of-thrones.gif"));

            DummyTopic = "LOL";

            DummyUser = "McPanda";

            
        }

       
    }
}
