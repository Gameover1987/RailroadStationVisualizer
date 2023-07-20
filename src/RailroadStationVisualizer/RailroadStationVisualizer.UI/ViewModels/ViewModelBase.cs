using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;
using System.Windows;

namespace RailroadStationVisualizer.UI.ViewModels
{
    /// <summary>
    /// Базовый класс для всех ViewModel'ей.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private static readonly int MainThreadId;

        static ViewModelBase()
        {
            MainThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        /// <summary>
        /// Сообщает об изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Сообщает об изменении значений всех свойств.
        /// </summary>
        protected void OnPropertyChanged()
        {
            RaisePropertyChangedEvent(string.Empty);
        }

        /// <summary>
        /// Сообщает об изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            OnPropertyChangedImpl(propertyName);
        }

        /// <summary>
        ///     Сообщает об изменении значения свойства.
        /// </summary>
        /// <param name="propertyExpression">Выражения для получения имени свойства.</param>
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);

            OnPropertyChanged(propertyName);
        }

        /// <summary>
        ///     Возвращает название свойства по выражению.
        /// </summary>
        /// <param name="propertyExpression">Выражение для получения имени свойства.</param>
        /// <returns></returns>
        protected string GetPropertyName(LambdaExpression propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return memberExpression.Member.Name;
        }

        protected void ExecuteInUIThread(Action action)
        {
            Application.Current?.Dispatcher.Invoke(action);
        }

        protected T ExecuteInUIThread<T>(Func<T> func)
        {
            var result = default(T);

            Application.Current?.Dispatcher.Invoke(() => result = func());

            return result;
        }

        protected void OnPropertyChangedImpl(string propertyName)
        {
            if (Thread.CurrentThread.ManagedThreadId == MainThreadId)
                RaisePropertyChangedEvent(propertyName);
            else
                ExecuteInUIThread(() => RaisePropertyChangedEvent(propertyName));
        }

        private void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshProperty(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        public void Refresh()
        {
            OnPropertyChanged();
        }
    }
}
