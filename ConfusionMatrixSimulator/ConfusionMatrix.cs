using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusionMatrixSimulator
{
    public class ConfusionMatrix
    {
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

        public ConfusionMatrix()
        {
            TruePositives = 0;
            FalsePositives = 0;
            FalseNegatives = 0;
            TrueNegatives = 0;

            CalculateScores();
        }

        public void CalculateScores()
        {
            // Calculate positives, negatives, and the total population
            Positives = TruePositives + FalseNegatives;
            Negatives = FalsePositives + TrueNegatives;
            TotalPopulation = TruePositives + FalseNegatives + FalsePositives + TrueNegatives;

            // Calculate true positive rate (TPR), false positive rate (FPR), false negative rate (FNR), and true negative rates (TNR)
            if (TruePositives == 0 && FalseNegatives == 0)
            {
                TruePositiveRate = 0;
                FalseNegativeRate = 0;
            }
            else
            {
                TruePositiveRate = (float)TruePositives / (TruePositives + FalseNegatives);
                FalseNegativeRate = (float)FalseNegatives / (TruePositives + FalseNegatives);
            }

            if (FalsePositives == 0 && TrueNegatives == 0)
            {
                FalsePositiveRate = 0f;
                TrueNegativeRate = 0f;
            }
            else
            {
                FalsePositiveRate = (float)FalsePositives / (FalsePositives + TrueNegatives);
                TrueNegativeRate = (float)TrueNegatives / (FalsePositives + TrueNegatives);
            }

            // Informedness and prevalence threshold
            Informedness = TruePositiveRate + TrueNegativeRate - 1;

            if (TruePositiveRate == 0 && FalsePositiveRate == 0)
            {
                PrevalenceThreshold = 0f;
            }
            else
            {
                if ((TruePositiveRate - FalsePositiveRate) == 0)
                {
                    PrevalenceThreshold = 0f;
                }
                else
                {
                    PrevalenceThreshold = ((float)Math.Sqrt(TruePositiveRate * FalsePositiveRate)
                                - FalsePositiveRate) / (TruePositiveRate - FalsePositiveRate);
                }
            }


            // Prevalence
            // Accuracy
            if (Positives == 0 && Negatives == 0)
            {
                Prevalence = 0;
                Accuracy = 0;
            }
            else
            {
                Prevalence = (float) Positives / (Positives + Negatives);
                Accuracy = (float) (TruePositives + TrueNegatives) / (Positives + Negatives);
            }

            // Positive predictive value (PPV) also called precision
            // False omission rate (FOR)
            // False Discovery rate (FDR)
            // Negative predictive value (NPV)
            if (TruePositives == 0 && FalsePositives == 0)
            {
                PositivePredictiveValue = 0f;
                FalseDiscoveryRate = 0f;
            }
            else
            {
                PositivePredictiveValue = (float)TruePositives / (TruePositives + FalsePositives);
                FalseDiscoveryRate = (float)FalsePositives / (TruePositives + FalsePositives);
            }

            if (FalseNegatives == 0 && TrueNegatives == 0)
            {
                FalseOmissionRate = 0f;
                NegativePredictiveValue = 0f;
            }
            else
            {
                FalseOmissionRate = (float)FalseNegatives / (FalseNegatives + TrueNegatives);
                NegativePredictiveValue = (float)TrueNegatives / (FalseNegatives + TrueNegatives);
            }

            // Positive likelihood ratio (LR+)
            // Negative likelihood ratio (LR-)
            // Markedness (MK)
            // Diagnostic odds ratio (DOR)
            if (FalsePositiveRate == 0)
            {
                PositiveLikelihoodRatio = 0f;
            }
            else
            {
                PositiveLikelihoodRatio = (float)TruePositiveRate / FalsePositiveRate;
            }

            if (TrueNegativeRate == 0)
            {
                NegativeLikelihoodRatio = 0f;
            }
            else
            {
                NegativeLikelihoodRatio = (float)FalseNegativeRate / TrueNegativeRate;
            }

            Markedness = PositivePredictiveValue + NegativePredictiveValue - 1;

            if (NegativeLikelihoodRatio == 0)
            {
                DiagnosticOddsRatio = 0;
            }
            else
            {
                DiagnosticOddsRatio = (float)PositiveLikelihoodRatio / NegativeLikelihoodRatio;
            }

            // Balanced accuracy (BA)
            // F1 score
            // Fowlkes-Mallows index (FM)
            // Matthews correlation coefficient (MCC)
            // Threat score (TS), critical success index (CSI), Jaccard index
            BalancedAccuracy = (TruePositiveRate + TrueNegativeRate) / 2;
            if (PositivePredictiveValue == 0 && TruePositiveRate == 0)
            {
                F1Score = 0;
            } 
            else
            {
                F1Score = (2 * PositivePredictiveValue * TruePositiveRate) / (PositivePredictiveValue + TruePositiveRate);
            }
            FowlkesMallowsIndex = (float)Math.Sqrt(PositivePredictiveValue * TruePositiveRate);
            MatthewsCorrelationCoefficient =
                (float)Math.Sqrt(TruePositiveRate * TrueNegativeRate * PositivePredictiveValue * NegativePredictiveValue)
                - (float)Math.Sqrt(FalseNegativeRate * FalsePositiveRate * FalseOmissionRate * FalseDiscoveryRate);

            if (TruePositives == 0 && FalseNegatives == 0 && FalsePositives == 0)
            {
                JaccardIndex = 0;
            }
            else
            {
                JaccardIndex = (float) TruePositives / (TruePositives + FalseNegatives + FalsePositives);
            }
        }

        #region FundamentalScores
        // Fundamental scores
        public int TruePositives { get; set; }
        public int FalseNegatives { get; set; }
        public int FalsePositives { get; set; }
        public int TrueNegatives { get; set; }
        #endregion

        #region SummaryScores
        // Summary scores
        public int Positives
        {
            get => _positives;
            private set
            {
                _positives = value;
            }
        }

        public int Negatives
        {
            get => _negatives;
            private set
            {
                _negatives = value;
            }
        }

        public int TotalPopulation
        {
            get => _totalPopulation;
            private set
            {
                _totalPopulation = value;
            }
        }
        #endregion

        #region TruePositiveRate, FalseNegativeRate, FalsePositiveRate, TrueNegativeRate
        // True positive rate (recall, sensitivity), false negative rate (type II error), false positive rate (type I error), 
        // and true negative rate (specificity)
        public float TruePositiveRate
        {
            get => _truePositiveRate;
            private set
            {
                _truePositiveRate = value;
            }
        }

        public float FalsePositiveRate
        {
            get => _falsePositiveRate;
            private set
            {
                _falsePositiveRate = value;
            }
        }

        public float FalseNegativeRate
        {
            get => _falseNegativeRate;
            private set
            {
                _falseNegativeRate = value;
            }
        }

        public float TrueNegativeRate
        {
            get => _trueNegativeRate;
            private set
            {
                _trueNegativeRate = value;
            }
        }
        #endregion

        #region Informedness, PrevalenceThreshold
        // Informedness and prevalence threshold
        public float Informedness
        {
            get => _informedness;
            private set
            {
                _informedness = value;
            }
        }
        public float PrevalenceThreshold
        {
            get => _prevalenceThreshold;
            private set
            {
                _prevalenceThreshold = value;
            }
        }
        #endregion

        #region Prevalence and accuracy
        public float Prevalence
        {
            get => _prevalence;
            private set
            {
                _prevalence = value;
            }
        }

        public float Accuracy
        {
            get => _accuracy;
            private set
            {
                _accuracy = value;
            }
        }
        #endregion

        #region PositivePredictiveValue, False Omission Rate, False Discovery Rate, Negative Predictive Value
        // Positive predictive value (precision), false omission rate, false discovery rate, and negative predictive value
        public float PositivePredictiveValue
        {
            get => _positivePredictiveValue;
            private set
            {
                _positivePredictiveValue = value;
            }
        }

        public float FalseOmissionRate
        {
            get => _falseOmissionRate;
            private set
            {
                _falseOmissionRate = value;
            }
        }

        public float FalseDiscoveryRate
        {
            get => _falseDiscoveryRate;
            private set
            {
                _falseDiscoveryRate = value;
            }
        }

        public float NegativePredictiveValue
        {
            get => _negativePredictiveValue;
            private set
            {
                _negativePredictiveValue = value;
            }
        }

        #endregion

        #region LR+, LR-, Markedness, DOR

        // Positive likelihood ratio, negative likelihood ratio, markedness, and diagnostic odds ratio
        public float PositiveLikelihoodRatio
        {
            get => _positiveLikelihoodRatio;
            private set
            {
                _positiveLikelihoodRatio = value;
            }
        }

        public float NegativeLikelihoodRatio
        {
            get => _negativeLikelihoodRatio;
            private set
            {
                _negativeLikelihoodRatio = value;
            }
        }

        public float Markedness
        {
            get => _markedness;
            private set
            {
                _markedness = value;
            }
        }

        public float DiagnosticOddsRatio
        {
            get => _diagnosticOddsRatio;
            private set
            {
                _diagnosticOddsRatio = value;
            }
        }

        #endregion

        #region BA, F1score, FM, MCC and Jaccard
        // Balanced accuracy
        // F1 score
        // Fowlkes-Mallows index
        // Matthews correlation coefficient
        // Threat score (critical success index, Jaccard index)
        public float BalancedAccuracy
        {
            get => _balancedAccuracy;
            private set
            {
                _balancedAccuracy = value;
            }
        }

        public float F1Score
        {
            get => _f1Score;
            private set
            {
                _f1Score = value;
            }
        }

        public float FowlkesMallowsIndex
        {
            get => _fowlkesMallowsIndex;
            private set
            {
                _fowlkesMallowsIndex = value;
            }
        }

        public float MatthewsCorrelationCoefficient
        {
            get => _matthewsCorrelationCoefficient;
            private set
            {
                _matthewsCorrelationCoefficient = value;
            }
        }

        public float JaccardIndex
        {
            get => _jaccardIndex;
            private set
            {
                _jaccardIndex = value;
            }
        }

        #endregion
    }

}
