using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZemberekDotNet.Morphology;
using ZemberekDotNet.Morphology.Analysis;
using ZemberekDotNet.Morphology.Lexicon;
using ZemberekDotNet.Normalization;
using ZemberekDotNet.Tokenization;

namespace deneme2
{
    public partial class morpho : Form
    {
        public morpho()
        {
            InitializeComponent();
        }

        public string icerik2;
        public string icerik3;


        private void button1_Click(object sender, EventArgs e)
        {
            string metin = icerik2;
            TurkishMorphology morphology = TurkishMorphology.CreateWithDefaults();
            var words = metin.Split(' ').Distinct().ToList();
            textBox1.Text = $"{words.Count+1}";

            HashSet<string> uniqueResults = new HashSet<string>();


            foreach (var token in words)
            {
                // Kelimenin morfolojik analizini al
                WordAnalysis results = morphology.Analyze(token);
                var result1 = results.GetAnalysisResults();
                foreach (var result in result1)
                {

                    uniqueResults.Add(result.GetStem());
                }
            }

            foreach (var uniqueResult in uniqueResults)
            {
                richTextBox1.Text += uniqueResult + " ";
            }
            string metinn = richTextBox1.Text.ToString();
            string[] kelimeler = metinn.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            textBox2.Text = $"{kelimeler.Length.ToString()}";
        }





        private void button2_Click(object sender, EventArgs e)
        {
            TurkishMorphology morphology = TurkishMorphology.Builder().SetLexicon(RootLexicon.GetDefault()).Build();
            TurkishTokenizer tokenizer = TurkishTokenizer.Default;
            string lookupRoot = "normalization";
            string lmPath = "lm.2gram.slm";
            TurkishSentenceNormalizer normalizer = new TurkishSentenceNormalizer(morphology, lookupRoot, lmPath);
            // Metindeki hatalı yazımları düzeltme işlemi.
            string duzeltilmisMetin = normalizer.Normalize(icerik3);
            richTextBox2.Text = RemovePunctuation(duzeltilmisMetin);

        }

        private string RemovePunctuation(string text)
        {
            return Regex.Replace(text, @"[^\w\s]", "");
        }
    }
}
