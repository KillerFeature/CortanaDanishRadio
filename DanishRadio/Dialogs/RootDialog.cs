using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DanishRadio.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);


            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            podcast pod = new podcast();

            var activity = await result as Activity;
            var message = context.MakeMessage();

            // This handles cortana invokation it is usually good to do a very short invokation reply.
            var isCortanalaunch = activity.Entities.Where(e => e.Type == "Intent" && e.Properties["name"].ToString() == "Microsoft.Launch").Any();
            
            if (isCortanalaunch)
            {
                message.Text = "What do you want me to play?";
                //message.Speak = @"<voice name=""Microsoft Server Speech Text to Speech Voice (da-DK, HelleRUS)"">Hvad skal jeg spille?</voice>";
                //message.Speak = SSMLHelper.Speak("What to play?"); //<voice name=""Microsoft Server Speech Text to Speech Voice (da-DK, HelleRUS)"">Hvad skal jeg spille?</voice>";
                message.InputHint = InputHints.ExpectingInput;
            }
            else
            {
           
            message.Attachments = new List<Attachment>();


            if (activity.Text.Contains("24") || activity.Text.ToLower().Contains("twenty four"))
            {
                MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://live.taleradio.dk/Web") };
                AudioCard audioCard = new AudioCard() {Media = medias,};
                Attachment audioCardAttach = audioCard.ToAttachment();
                message.Attachments.Add(audioCardAttach);
                message.InputHint = InputHints.AcceptingInput;
                message.Text = "Tuning in to Radio twentyfour seven";
                
            }
            else if (matchRegex(activity.Text.ToLower(), @"(B|D|E|G|P|the|tea|tee|T)\s?(1|one)"))
            {
                MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://live-icy.gslb01.dr.dk:80/A/A03H.mp3") };
                AudioCard audioCard = new AudioCard() { Media = medias, };
                Attachment audioCardAttach = audioCard.ToAttachment();
                message.Attachments.Add(audioCardAttach);
                message.InputHint = InputHints.AcceptingInput;
                message.Text = "Tuning in to P1.";

            }
                else if (matchRegex(activity.Text.ToLower(), @"(B|D|E|G|P|the|tea|tee|T)\s?(2|two|too)"))
                {
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://live-icy.gslb01.dr.dk:80/A/A04H.mp3") };
                AudioCard audioCard = new AudioCard() { Media = medias, };
                Attachment audioCardAttach = audioCard.ToAttachment();
                message.Attachments.Add(audioCardAttach);
                message.InputHint = InputHints.AcceptingInput;
                message.Text = "Tuning in to P2.";

            }
                else if (matchRegex(activity.Text.ToLower(), @"(B|D|E|G|P|the|tea|tee|T)\s?(5|five)"))
                {
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://live-icy.gslb01.dr.dk:80/A/A25H.mp3") };
                AudioCard audioCard = new AudioCard() { Media = medias, };
                Attachment audioCardAttach = audioCard.ToAttachment();
                message.Attachments.Add(audioCardAttach);
                message.InputHint = InputHints.AcceptingInput;
                message.Text = "Tuning in to P5.";

            }
                else if (matchRegex(activity.Text.ToLower(), @"(B|D|E|G|P|the|tea|tee|T)\s?(3|tree|three)"))
                {
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://live-icy.gslb01.dr.dk:80/A/A05H.mp3") };
                AudioCard audioCard = new AudioCard() { Media = medias, };
                Attachment audioCardAttach = audioCard.ToAttachment();
                message.Attachments.Add(audioCardAttach);
                message.InputHint = InputHints.AcceptingInput;
                message.Text = "Tuning in to P3.";

            }
            else if (activity.Text.ToLower().Contains("jazz"))
            {
                MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://live-icy.gslb01.dr.dk:80/A/A22H.mp3") };
                AudioCard audioCard = new AudioCard() { Media = medias, };
                Attachment audioCardAttach = audioCard.ToAttachment();
                message.Attachments.Add(audioCardAttach);
                message.InputHint = InputHints.AcceptingInput;
                message.Text = "Tuning in to P8 Jazz.";

            }
            else if (activity.Text.ToLower().Contains("mix") || activity.Text.ToLower().Contains("mechs"))
            {
                MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://live-icy.gslb01.dr.dk:80/A/A21H.mp3") };
                AudioCard audioCard = new AudioCard() { Media = medias, };
                Attachment audioCardAttach = audioCard.ToAttachment();
                message.Attachments.Add(audioCardAttach);
                message.InputHint = InputHints.AcceptingInput;
                message.Text = "Tuning in to P7 Mix.";

            }
                else if (activity.Text.ToLower().Contains("nova"))
                {
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://195.184.101.204/nova128") };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Tuning in to Nova FM";

                }
                else if (activity.Text.ToLower().Contains("rock"))
                {
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://stream.myrock.fm/myrock128") };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Tuning in to My Rock";

                }
                else if (activity.Text.ToLower().Contains("pop"))
                {
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://195.184.101.202/pop128") };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Tuning in to POP FM";

                }
                else if (activity.Text.ToLower().Contains("voice"))
                {
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl("http://195.184.101.203/voice128") };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Tuning in to : THE VOICE";

                }
                else if (activity.Text.ToLower().Contains("news"))
                {
                    // var murl = pod.getmediaURL("https://www.dr.dk/mu/feed/p1-radioavisen.xml?format=podcast&limit=10");

                    var item = await pod.getmediaURL("https://arkiv.radio24syv.dk/audiopodcast/channel/3561248");

                    var diffString = "";

                    if (DateTime.Now.AddHours(1).Subtract(item.pubDate).Hours < 1 )
                    {
                        diffString = DateTime.Now.AddHours(1).Subtract(item.pubDate).Minutes.ToString() + " minutes";
                    }
                    else
                    {
                        diffString = DateTime.Now.AddHours(1).Subtract(item.pubDate).Hours.ToString() + " hours";
                    }
                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl(item.url)};
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Playing the news from " + diffString +" ago";

                }
                else if (activity.Text.ToLower().Contains("campaign") || activity.Text.ToLower().Contains("trail"))
                {
                    // var murl = pod.getmediaURL("https://www.dr.dk/mu/feed/p1-radioavisen.xml?format=podcast&limit=10");

                    var item = await pod.getmediaURL("https://arkiv.radio24syv.dk/audiopodcast/channel/13965705");

                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl(item.url) };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;

                    message.Text = "Playing Campaign Trail";
                }
                else if (activity.Text.ToLower().Contains("azure") || activity.Text.ToLower().Contains("azure podcast") || activity.Text.ToLower().Contains("assure podcast") || activity.Text.ToLower().Contains("assure "))
                {
                    // var murl = pod.getmediaURL("https://www.dr.dk/mu/feed/p1-radioavisen.xml?format=podcast&limit=10");

                    var item = await pod.getmediaURL("http://feeds.feedburner.com/TheAzurePodcast?format=xml");

                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl(item.url) };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Playing The Azure Podcast";
                }
                else if (activity.Text.ToLower().Contains("sunshine"))
                {
                    var item = await pod.getmediaURL("https://arkiv.radio24syv.dk/audiopodcast/channel/13967997");

                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl(item.url) };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Playing : Are you Sunshine?";
                }
                else if (activity.Text.ToLower().Contains("short"))
                {
                    var item = await pod.getmediaURLs("https://arkiv.radio24syv.dk/audiopodcast/channel/10839671");

                    MediaUrl[] medias = new MediaUrl[] { new MediaUrl(item[item.Count-2].url), new MediaUrl(item[item.Count-1].url) };
                    AudioCard audioCard = new AudioCard() { Media = medias, };
                    Attachment audioCardAttach = audioCard.ToAttachment();
                    message.Attachments.Add(audioCardAttach);
                    message.InputHint = InputHints.AcceptingInput;
                    message.Text = "Playing : Kirsten Birgit";
                }

                else if (activity.Text.Contains("help") )
            {
                message.Text = $"Say 24 for radio twentyfour seven. Say P1, P2 or P3 for DR Programs";
                message.InputHint = InputHints.ExpectingInput;
            }
            else
            {
                message.Text = $"I heard {activity.Text}. I don't get that. Try again, or say help to get availible stations.";
                message.InputHint = InputHints.ExpectingInput;
            }
            }
            message.Speak = message.Text;


            await context.PostAsync(message);
            context.Wait(MessageReceivedAsync);
        }
    private bool matchRegex(string input, string regex) {
            Regex rx = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return rx.IsMatch(input);
            
        }

    }
}