// -----------------------------------------------------------------------
// <copyright file="ViewModel.cs" company="UBS AG">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace avalon.fiddler.plugin
{
    using System.ComponentModel;

    using ICSharpCode.AvalonEdit;

    using avalon.fiddler.plugin.Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Body { get; set; }
    }
}