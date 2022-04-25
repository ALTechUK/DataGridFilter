#region (c) 2019 Gilles Macabies

// Author     : Gilles Macabies
// Solution   : DataGridFilter
// Projet     : DataGridFilter
// File       : DataGridTextColumn.cs
// Created    : 09/11/2019

#endregion (c) 2019 Gilles Macabies

using System.Globalization;
using System.Windows;
using System.Windows.Data;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace

namespace FilterDataGrid
{
    public interface IColumn
    {
        string FieldName { get; set; }
        bool IsColumnFiltered { get; set; }
        object Header { get; set; }
        DataTemplate HeaderTemplate { get; set; }
        bool CanUserSort { get; set; }

        string BindingStringFormat { get; set; }
        CultureInfo BindingConverterCulture { get; set; }

        void SetBinding(string propertyName, CultureInfo culture, string stringFormat);
        string TryGetBindingPath();
    }

    public sealed class DataGridTemplateColumn : System.Windows.Controls.DataGridTemplateColumn, IColumn
    {
        #region Public Fields

        /// <summary>
        /// FieldName Dependency Property.
        /// </summary>
        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register("FieldName", typeof(string), typeof(DataGridTemplateColumn),
                new PropertyMetadata(""));

        /// <summary>
        /// IsColumnFiltered Dependency Property.
        /// </summary>
        public static readonly DependencyProperty IsColumnFilteredProperty =
                    DependencyProperty.Register("IsColumnFiltered", typeof(bool), typeof(DataGridTemplateColumn),
                new PropertyMetadata(false));

        #endregion Public Fields

        #region Public Properties

        public string FieldName
        {
            get => (string)GetValue(FieldNameProperty);
            set => SetValue(FieldNameProperty, value);
        }

        public bool IsColumnFiltered
        {
            get => (bool)GetValue(IsColumnFilteredProperty);
            set => SetValue(IsColumnFilteredProperty, value);
        }

        #endregion Public Properties

        public string BindingStringFormat 
        {
            get => null;
            set { }
        }
        public CultureInfo BindingConverterCulture
        {
            get => null;
            set { }
        }
        public void SetBinding(string propertyName, CultureInfo culture, string stringFormat) { }
        public string TryGetBindingPath() => null;
    }

    public sealed class DataGridTextColumn : System.Windows.Controls.DataGridTextColumn, IColumn
    {
        #region Public Fields

        /// <summary>
        /// FieldName Dependency Property.
        /// </summary>
        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register("FieldName", typeof(string), typeof(DataGridTextColumn),
                new PropertyMetadata(""));

        /// <summary>
        /// IsColumnFiltered Dependency Property.
        /// </summary>
        public static readonly DependencyProperty IsColumnFilteredProperty =
                    DependencyProperty.Register("IsColumnFiltered", typeof(bool), typeof(DataGridTextColumn),
                new PropertyMetadata(false));

        #endregion Public Fields

        #region Public Properties

        public string FieldName
        {
            get => (string)GetValue(FieldNameProperty);
            set => SetValue(FieldNameProperty, value);
        }

        public bool IsColumnFiltered
        {
            get => (bool)GetValue(IsColumnFilteredProperty);
            set => SetValue(IsColumnFilteredProperty, value);
        }

        #endregion Public Properties

        public string BindingStringFormat
        {
            get => Binding?.StringFormat;
            set
            {
                if (Binding != null)
                    Binding.StringFormat = value;
            }
        }
        public CultureInfo BindingConverterCulture
        {
            get => ((Binding)Binding).ConverterCulture;
            set => ((Binding)Binding).ConverterCulture = value;
        }

        public void SetBinding(string propertyName, CultureInfo culture, string stringFormat)
        {
            Binding = new Binding(propertyName) 
            {
                ConverterCulture = culture,
                StringFormat = stringFormat
            };
        }

        public string TryGetBindingPath() => ((Binding)Binding).Path.Path;
    }

    public sealed class DataGridComboBoxColumn : System.Windows.Controls.DataGridComboBoxColumn, IColumn
    {
        #region Public Fields

        /// <summary>
        /// FieldName Dependency Property.
        /// </summary>
        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register("FieldName", typeof(string), typeof(DataGridComboBoxColumn),
                new PropertyMetadata(""));

        /// <summary>
        /// IsColumnFiltered Dependency Property.
        /// </summary>
        public static readonly DependencyProperty IsColumnFilteredProperty =
                    DependencyProperty.Register("IsColumnFiltered", typeof(bool), typeof(DataGridComboBoxColumn),
                new PropertyMetadata(false));

        #endregion Public Fields

        #region Public Properties

        public string FieldName
        {
            get => (string)GetValue(FieldNameProperty);
            set => SetValue(FieldNameProperty, value);
        }

        public bool IsColumnFiltered
        {
            get => (bool)GetValue(IsColumnFilteredProperty);
            set => SetValue(IsColumnFilteredProperty, value);
        }

        #endregion Public Properties

        public string BindingStringFormat
        {
            get => SelectedItemBinding?.StringFormat;
            set
            {
                if (SelectedItemBinding != null)
                    SelectedItemBinding.StringFormat = value;
            }
        }
        public CultureInfo BindingConverterCulture
        {
            get => ((Binding)SelectedItemBinding).ConverterCulture;
            set => ((Binding)SelectedItemBinding).ConverterCulture = value;
        }

        public void SetBinding(string propertyName, CultureInfo culture, string stringFormat)
        {
            SelectedItemBinding = new Binding(propertyName) 
            { 
                ConverterCulture = culture,
                StringFormat = stringFormat
            };
        }
        public string TryGetBindingPath() => ((Binding)SelectedItemBinding).Path.Path;
    }
}