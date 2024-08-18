using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusionMatrixSimulator
{
    public class ConfusionMatrixSimulatorViewModel : ViewModelBase
    {
        private int _truePositives;
        private int _falseNegatives;
        private int _falsePositives;
        private int _trueNegatives;

        private int _positives;
        private int _negatives;
        private int _totalPopulation;

        private float _truePositiveRate;
        private float _falsePositiveRate;
        private float _falseNegativeRate;
        private float _trueNegativeRate;

        private float _informedness;
        private float _prevalenceThreshold;

        private float _prevalence;
        private float _accuracy;

        private float _positiveLikelihoodRatio;
        private float _negativeLikelihoodRatio;
        private float _markedness;
        private float _diagnosticOddsRatio;

        private float _positivePredictiveValue;
        private float _falseOmissionRate;
        private float _falseDiscoveryRate;
        private float _negativePredictiveValue;

        private float _balancedAccuracy;
        private float _f1Score;
        private float _fowlkesMallowsIndex;
        private float _matthewsCorrelationCoefficient;
        private float _jaccardIndex;

        private ConfusionMatrix _confusionMatrix;

        public ConfusionMatrixSimulatorViewModel()
        {
            _confusionMatrix = new ConfusionMatrix
            {
                TruePositives = 0,
                FalseNegatives = 0,
                FalsePositives = 0,
                TrueNegatives = 0
            };

            TruePositives = _confusionMatrix.TruePositives;
            FalseNegatives = _confusionMatrix.FalseNegatives;
            FalsePositives = _confusionMatrix.FalsePositives;
            TrueNegatives = _confusionMatrix.TrueNegatives;

            _confusionMatrix.CalculateScores();
        }

        public void CalculateScores()
        {
            _confusionMatrix.CalculateScores();

            // Update summary scores
            Positives = _confusionMatrix.Positives;
            Negatives = _confusionMatrix.Negatives;
            TotalPopulation = _confusionMatrix.TotalPopulation;

            // Update true positive rate, false negative rate, false positive rate, and true negative rate
            TruePositiveRate = _confusionMatrix.TruePositiveRate;
            FalsePositiveRate = _confusionMatrix.FalsePositiveRate;
            FalseNegativeRate = _confusionMatrix.FalseNegativeRate;
            TrueNegativeRate = _confusionMatrix.TrueNegativeRate;

            // Informedness, prevalence threshold
            Informedness = _confusionMatrix.Informedness;
            PrevalenceThreshold = _confusionMatrix.PrevalenceThreshold;

            // Prevalence, accuracy
            Prevalence = _confusionMatrix.Prevalence;
            Accuracy = _confusionMatrix.Accuracy;

            // Positive predictive value, false omission rate, false discovery rate, and negative predictive value
            PositivePredictiveValue = _confusionMatrix.PositivePredictiveValue;
            FalseOmissionRate = _confusionMatrix.FalseOmissionRate;
            FalseDiscoveryRate = _confusionMatrix.FalseDiscoveryRate;
            NegativePredictiveValue = _confusionMatrix.NegativePredictiveValue;

            // LR+, LR-, Markedness, DOR
            PositiveLikelihoodRatio = _confusionMatrix.PositiveLikelihoodRatio;
            NegativeLikelihoodRatio = _confusionMatrix.NegativeLikelihoodRatio;
            Markedness = _confusionMatrix.Markedness;
            DiagnosticOddsRatio = _confusionMatrix.DiagnosticOddsRatio;

            // BA, F1score, FM, MCC, and Jaccard
            BalancedAccuracy = _confusionMatrix.BalancedAccuracy;
            F1Score = _confusionMatrix.F1Score;
            FowlkesMallowsIndex = _confusionMatrix.FowlkesMallowsIndex;
            MatthewsCorrelationCoefficient = _confusionMatrix.MatthewsCorrelationCoefficient;
            JaccardIndex = _confusionMatrix.JaccardIndex;
        }

        #region FundamentalScores
        public int TruePositives
        {
            get => _truePositives;
            set
            {
                _truePositives = value;
                _confusionMatrix.TruePositives = value;
                OnPropertyChanged(nameof(TruePositives));
                CalculateScores();
            }
        }

        public int FalseNegatives
        {
            get => _falseNegatives;
            set
            {
                _falseNegatives = value;
                _confusionMatrix.FalseNegatives = value;
                OnPropertyChanged(nameof(FalseNegatives));
                CalculateScores();
            }
        }

        public int FalsePositives
        {
            get => _falsePositives;
            set
            {
                _falsePositives = value;
                _confusionMatrix.FalsePositives = value;
                OnPropertyChanged(nameof(FalsePositives));
                CalculateScores();
            }
        }

        public int TrueNegatives
        {
            get => _trueNegatives;
            set
            {
                _trueNegatives = value;
                _confusionMatrix.TrueNegatives = value;
                OnPropertyChanged(nameof(TrueNegatives));
                CalculateScores();
            }
        }
        #endregion

        #region SummaryScores
        // Positive
        public int Positives
        {
            get => _positives; 
            set
            {
                _positives = value;
                OnPropertyChanged(nameof(Positives));
            }
        }

        // Negative
        public int Negatives
        {
            get => _negatives;
            set
            {
                _negatives = value;
                OnPropertyChanged(nameof(Negatives));
            }
        }

        // Total population
        public int TotalPopulation
        {
            get => _totalPopulation;
            set
            {
                _totalPopulation = value;
                OnPropertyChanged(nameof(TotalPopulation));
            }
        }

        #endregion

        #region TruePositiveRate, FalseNegativeRate, FalsePositiveRate, TrueNegativeRate
        public float TruePositiveRate
        {
            get => _truePositiveRate;
            set
            {
                _truePositiveRate = value;
                OnPropertyChanged(nameof(TruePositiveRate));
            }
        }

        public float FalseNegativeRate
        {
            get => _falseNegativeRate;
            set
            {
                _falseNegativeRate = value;
                OnPropertyChanged(nameof(FalseNegativeRate));
            }
        }

        public float FalsePositiveRate
        {
            get => _falsePositiveRate;
            set
            {
                _falsePositiveRate = value;
                OnPropertyChanged(nameof(FalsePositiveRate));
            }
        }

        public float TrueNegativeRate
        {
            get => _trueNegativeRate;
            set
            {
                _trueNegativeRate = value;
                OnPropertyChanged(nameof(TrueNegativeRate));
            }
        }

        #endregion

        #region Informedness, PrevalenceThreshold
        public float Informedness
        {
            get => _informedness;
            set
            {
                _informedness = value;
                OnPropertyChanged(nameof(Informedness));
            }
        }

        public float PrevalenceThreshold
        {
            get => _prevalenceThreshold;
            set
            {
                _prevalenceThreshold = value;
                OnPropertyChanged(nameof(PrevalenceThreshold));
            }
        }

        #endregion

        #region Prevalence, Accuracy
        public float Prevalence
        {
            get => _prevalence;
            set
            {
                _prevalence = value;
                OnPropertyChanged(nameof(Prevalence));
            }
        }

        public float Accuracy
        {
            get => _accuracy;
            set
            {
                _accuracy = value;
                OnPropertyChanged(nameof(Accuracy));
            }
        }

        #endregion

        #region PositivePredictiveValue, FalseOmissionRate, FalseDiscoveryRate, NegativePredictiveValue

        public float PositivePredictiveValue
        {
            get => _positivePredictiveValue;
            set
            {
                _positivePredictiveValue = value;
                OnPropertyChanged(nameof(PositivePredictiveValue));
            }
        }

        public float FalseOmissionRate
        {
            get => _falseOmissionRate;
            set
            {
                _falseOmissionRate = value;
                OnPropertyChanged(nameof(FalseOmissionRate));
            }
        }

        public float FalseDiscoveryRate
        {
            get => _falseDiscoveryRate;
            set
            {
                _falseDiscoveryRate = value;
                OnPropertyChanged(nameof(FalseDiscoveryRate));
            }
        }

        public float NegativePredictiveValue
        {
            get => _negativePredictiveValue;
            set
            {
                _negativePredictiveValue = value;
                OnPropertyChanged(nameof(NegativePredictiveValue));
            }
        }

        #endregion

        #region LR+, LR-, Markedness, DOR

        public float PositiveLikelihoodRatio
        {
            get => _positiveLikelihoodRatio;
            set
            {
                _positiveLikelihoodRatio = value;
                OnPropertyChanged(nameof(PositiveLikelihoodRatio));
            }
        }

        public float NegativeLikelihoodRatio
        {
            get => _negativeLikelihoodRatio;
            set
            {
                _negativeLikelihoodRatio = value;
                OnPropertyChanged(nameof(NegativeLikelihoodRatio));
            }
        }

        public float Markedness
        {
            get => _markedness;
            set
            {
                _markedness = value;
                OnPropertyChanged(nameof(Markedness));
            }
        }

        public float DiagnosticOddsRatio
        {
            get => _diagnosticOddsRatio;
            set
            {
                _diagnosticOddsRatio = value;
                OnPropertyChanged(nameof(DiagnosticOddsRatio));
            }
        }

        #endregion

        #region BA, F1Score, FM, MCC, and Jaccard

        public float BalancedAccuracy
        {
            get => _balancedAccuracy;
            set
            {
                _balancedAccuracy = value;
                OnPropertyChanged(nameof(BalancedAccuracy));
            }
        }

        public float F1Score
        {
            get => _f1Score;
            set
            {
                _f1Score = value;
                OnPropertyChanged(nameof(F1Score));
            }
        }

        public float FowlkesMallowsIndex
        {
            get => _fowlkesMallowsIndex;
            set
            {
                _fowlkesMallowsIndex = value;
                OnPropertyChanged(nameof(FowlkesMallowsIndex));
            }
        }

        public float MatthewsCorrelationCoefficient
        {
            get => _matthewsCorrelationCoefficient;
            set
            {
                _matthewsCorrelationCoefficient = value;
                OnPropertyChanged(nameof(MatthewsCorrelationCoefficient));
            }
        }

        public float JaccardIndex
        {
            get => _jaccardIndex;
            set
            {
                _jaccardIndex = value;
                OnPropertyChanged(nameof(JaccardIndex));
            }
        }

        #endregion
    }
}
