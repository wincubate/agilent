using System;
using System.Collections.ObjectModel;

namespace Wincubate.Threading.CaseStudyA.Data
{
    public class Participants : ObservableCollection<Participant>
    {
        public Participants()
        {
            this.Add(new Participant("Gulmann Henriksen",
                                       "Jesper",
                                       "Wincubate ApS",
                                       new Uri("pack://application:,,,/Wincubate.Threading.CaseStudyA.Data;component/JGH.jpg")));
            this.Add(new Participant("Grønfeldt",
                                       "Hans",
                                       "Codeblenderiet"));
            this.Add(new Participant("Finsen",
                                       "Kim",
                                       "Onomatopoietikon A/S"));
            this.Add(new Participant("Bastrup",
                                       "Rasmus",
                                       "Onomatopoietikon A/S"));
            this.Add(new Participant("Amini",
                                       "Armin",
                                       "Onomatopoietikon A/S"));
            this.Add(new Participant("Besson",
                                       "Luc",
                                       "Tools for Fools A/S"));
            this.Add(new Participant("Besson",
                                       "Beth",
                                       "Tools for Fools A/S"));
        }
    }
}
