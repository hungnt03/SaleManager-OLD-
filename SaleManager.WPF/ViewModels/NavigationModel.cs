using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.WPF.ViewModels
{
    public class NavigationModel<T> : BaseViewModel
    {
        //private static readonly Lazy<NavigationPage<T>> lazy = new Lazy<NavigationPage<T>>(() => new NavigationPage<T>());
        //public static NavigationPage<T> Instance { get { return lazy.Value; } }
        private Stack<T> _pages { set; get; }
        private T _currentPage { set; get; }
        public Stack<T> Pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
                OnPropertyChanged("Pages");
            }
        }
        public T CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public NavigationModel(T page)
        {
            Pages = new Stack<T>();
            Push(page);
        }
        public void Push(T page)
        {
            if (!Contains(page))
            {
                Pages.Push(page);
                CurrentPage = page;
            }
        }
        public void Pop()
        {
            if (Pages.Count > 1)
            {
                Pages.Pop();
                CurrentPage = Pages.Peek();
            }
        }
        private bool Contains(T item)
        {
            foreach(var page in Pages)
            {
                if (item.GetType().Equals(page.GetType()))
                {
                    return true;
                }  
            }
            return false;
        }
    }
}
