using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiTreeView
{
    public class FileManagerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Folder> folders;
        public ObservableCollection<Folder> Folders
        {
            get
            {
                return folders;
            }
            set
            {
                folders = value;
                OnPropertyChanged(nameof(Folders));
            }
        }
        public ICommand SortCommand { get; set; }

        public FileManagerViewModel()
        {
            this.Folders = GetFiles();
            this.SortCommand = new Command(SortTreeView);
        }

        private void SortTreeView(object obj)
        {
            this.Folders = new ObservableCollection<Folder>(this.folders.OrderBy(x => x.ItemName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Folder> GetFiles()
        {
            var nodeImageInfo = new ObservableCollection<Folder>();

            var doc = new Folder() { ItemName = "Documents", ImageIcon = "folder.png" };
            var download = new Folder() { ItemName = "Downloads", ImageIcon = "folder.png" };
            var mp3 = new Folder() { ItemName = "Music", ImageIcon = "folder.png" };
            var pictures = new Folder() { ItemName = "Pictures", ImageIcon = "folder.png" };
            var video = new Folder() { ItemName = "Videos", ImageIcon = "folder.png" };

            var pollution = new File() { ItemName = "Environmental Pollution.docx", ImageIcon = "word.png" };
            var globalWarming = new File() { ItemName = "Global Warming.ppt", ImageIcon = "ppt.png" };
            var sanitation = new File() { ItemName = "Sanitation.docx", ImageIcon = "word.png" };
            var socialNetwork = new File() { ItemName = "Social Network.pdf", ImageIcon = "pdfimage.png" };
            var youthEmpower = new File() { ItemName = "Youth Empowerment.pdf", ImageIcon = "pdfimage.png" };

            var tutorials = new File() { ItemName = "Tutorials.zip", ImageIcon = "zip.png" };
            var typeScript = new File() { ItemName = "TypeScript.7z", ImageIcon = "zip.png" };
            var uiGuide = new File() { ItemName = "UI-Guide.pdf", ImageIcon = "pdfimage.png" };

            var song = new File() { ItemName = "Gouttes", ImageIcon = "audio.png" };

            var camera = new File() { ItemName = "Camera Roll", ImageIcon = "folder.png" };
            var stone = new File() { ItemName = "Stone.jpg", ImageIcon = "image.png" };
            var wind = new File() { ItemName = "Wind.jpg", ImageIcon = "image.png" };

            var img0 = new File() { ItemName = "WIN_20160726_094117.JPG", ImageIcon = "people_circle23.png" };
            var img1 = new File() { ItemName = "WIN_20160726_094118.JPG", ImageIcon = "people_circle2.png" };

            var video1 = new File() { ItemName = "Naturals.mp4", ImageIcon = "video.png" };
            var video2 = new File() { ItemName = "Wild.mpeg", ImageIcon = "video.png" };

            doc.Files = new ObservableCollection<File>
            {
                pollution,
                globalWarming,
                sanitation,
                socialNetwork,
                youthEmpower
            };

            download.Files = new ObservableCollection<File>
            {
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.Files = new ObservableCollection<File>
            {
                song
            };

            pictures.Files = new ObservableCollection<File>
            {
                camera,
                stone,
                wind
            };

            camera.SubFiles = new ObservableCollection<File>
            {
                img0,
                img1
            };

            video.Files = new ObservableCollection<File>
            {
                video1,
                video2
            };

            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(video);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(doc);
            return nodeImageInfo;
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
