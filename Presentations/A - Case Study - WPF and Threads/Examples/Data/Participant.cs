using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wincubate.Threading.CaseStudyA.Data
{
    public class Participant : INotifyPropertyChanged
   {
      #region Properties

      static Uri ImageNotAvailableUri
      {
         get
         {
            return new Uri( "pack://application:,,,/Wincubate.Threading.CaseStudyA.Data;component/nophoto.gif" );
         }
      }

      public string FullName
      {
         get
         {
            return ( FirstName ?? "" ) + " " + ( LastName ?? "" );
         }
      }

      public string LastName
      {
         get
         {
            return _lastName;
         }
         set
         {
            _lastName = value;
            NotifyPropertyChanged();
            NotifyPropertyChanged( "FullName" );
         }
      }
      private string _lastName;

      public string FirstName
      {
         get
         {
            return _firstName;
         }
         set
         {
            _firstName = value;
            NotifyPropertyChanged();
            NotifyPropertyChanged( "FullName" );
         }
      }
      private string _firstName;

      public string Company
      {
         get
         {
            return _company;
         }
         set
         {
            _company = value;
            NotifyPropertyChanged();
         }
      }
      private string _company;

      public Uri ImageUri
      {
         get
         {
            return _imageUri;
         }
         set
         {
            _imageUri = value;
            NotifyPropertyChanged();
         }
      }
      private Uri _imageUri;

      #endregion

      #region Constructors

      public Participant()
         : this(
             "Gulmann Henriksen",
             "Jesper",
             "Wincubate",
             new Uri( "pack://application:,,,/Wincubate.Threading.CaseStudyA.Data;component/JGH.jpg" ) )
      {
      }

      public Participant( string lastName, string firstName, string company )
         : this(
             lastName,
             firstName,
             company,
             ImageNotAvailableUri )
      {
      }

      public Participant( string lastName, string firstName, string company, Uri imageUri )
      {
         LastName = lastName;
         FirstName = firstName;
         Company = company;
         ImageUri = imageUri;
      }

      #endregion

      #region INotifyPropertyChanged Members

      public event PropertyChangedEventHandler PropertyChanged;

      private void NotifyPropertyChanged( [CallerMemberName] string propertyName = null )
      {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      #endregion
   }
}
