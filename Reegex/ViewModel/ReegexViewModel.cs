using Reegex.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Reegex.ViewModel
{
    public class ReegexViewModel : ViewModelBase
    {
        #region Commands

        public ICommand MatchCommand { get; set; }

        #endregion

        #region Private vars

        string pattern;
        string expression;

        bool canHighlighted;
        bool isCaseSensitivity;
        bool isGlobal;

        bool isMatched;
        private bool isValidPattern;

        #endregion

        #region Public properties

        public string Pattern
        {
            get => pattern;
            set
            {
                if (value != pattern)
                {
                    pattern = value;

                    notifyPropertyChanged(nameof(Pattern));
                }
            }
        }
        public string Expression
        {
            get => expression;
            set
            {
                if (value != expression)
                {
                    expression = value;

                    notifyPropertyChanged(nameof(Expression));
                }
            }
        }

        public bool CanHighlighted
        {
            get => canHighlighted;
            set
            {
                if (value != canHighlighted)
                {
                    canHighlighted = value;

                    notifyPropertyChanged(nameof(CanHighlighted));
                }
            }
        }
        public bool IsCaseSensitivity
        {
            get => isCaseSensitivity;
            set
            {
                if (value != isCaseSensitivity)
                {
                    isCaseSensitivity = value;

                    notifyPropertyChanged(nameof(IsCaseSensitivity));
                }
            }
        }
        public bool IsGlobal
        {
            get => isGlobal;
            set
            {
                if (value != isGlobal)
                {
                    isGlobal = value;

                    notifyPropertyChanged(nameof(IsGlobal));
                }
            }
        }

        public bool IsMatched
        {
            get => isMatched;
            set
            {
                if (value != isMatched)
                {
                    isMatched = value;

                    notifyPropertyChanged(nameof(IsMatched));
                }
            }
        }

        public bool IsValidPattern
        {
            get => isValidPattern;
            set
            {
                if (value != isValidPattern)
                {
                    isValidPattern = IsValidRegex(Pattern);

                    notifyPropertyChanged(nameof(IsValidPattern));
                }
            }
        }

        #endregion

        /// <summary>
        /// Fregex constructor.
        /// </summary>
        public ReegexViewModel()
        {
            MatchCommand = new MatchCommand(Match);
        }

        /// <summary>
        /// Matches 
        /// </summary>
        public void Match()
        {
            IsMatched = Regex.IsMatch(Expression, Pattern, CanIgnoreCase());

            MessageBox.Show(IsMatched ? ":)" : ":(");
        }

        private RegexOptions CanIgnoreCase()
        {
            if (!isCaseSensitivity)
                return RegexOptions.IgnoreCase;

            return RegexOptions.None;
        }

        private static bool IsValidRegex(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return false;

            try
            {
                Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}
