using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gizmoskip_Mage_Simulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double crit_buff = 0;
            double time = 2.5;
            double max = 475;
            double min = 440;
            double multiplier = 1.06;
            double SP_Multiplier = 0.814;
            double Bonus_Spellpower = 0;
            double critical_multiplier = 2;
            double intellect = int.Parse(Intellect.Text);
            double intellectExtra = 0;

            if (((ComboBoxItem)Spec_Selection.SelectedItem).Content.ToString() == "Deep Frost")
            {
                crit_buff = 0;
                time = 2.5;
                max = 475;
                min = 440;
                multiplier = 1.06;
                critical_multiplier = 2;
                crit_buff += 0.1;
                if ((bool)AQ20_spells.IsChecked)
                {
                    max = 555;
                    min = 515;
                }
                if ((bool)Elixirs.IsChecked)
                {
                    Bonus_Spellpower += 50;
                }
            }

            if (((ComboBoxItem)Spec_Selection.SelectedItem).Content.ToString() == "Frost (Arcane Power)")
            {
                crit_buff = 0;
                time = 2.5;
                max = 475;
                min = 440;
                multiplier = 1.06;
                critical_multiplier = 2;
                crit_buff += 0.1;
                if ((bool)AQ20_spells.IsChecked)
                {
                    max = 555;
                    min = 515;
                }
                if ((bool)Elixirs.IsChecked)
                {
                    Bonus_Spellpower += 50;
                }
            }


            if (((ComboBoxItem)Spec_Selection.SelectedItem).Content.ToString() == "Deep Fire")
            {
                crit_buff = 0;
                time = 3;
                max = 561;
                min = 715;
                multiplier = 1.35;
                critical_multiplier = 2.1;
                SP_Multiplier = 1;
                if ((bool)AQ20_spells.IsChecked)
                {
                    max = 596;
                    min = 760;
                }
                if ((bool)Elixirs.IsChecked)
                {
                    Bonus_Spellpower += 75;
                }
                if ((bool)Netherwind.IsChecked)
                {
                    
                }
            }

            if ((bool)Flask.IsChecked)
            {
                Bonus_Spellpower += 150;
            }

            if ((bool)Dragonslayer.IsChecked)
            {
                crit_buff += 10;
            }

            if ((bool)Songflower.IsChecked)
            {
                crit_buff += 5;
            }

            if ((bool)Dire_Maul.IsChecked)
            {
                crit_buff += 3;
            }

            if ((bool)Moonkin.IsChecked)
            {
                crit_buff += 3;
            }

            if ((bool)Raid_Buffs.IsChecked)
            {
                intellectExtra += 51;
                intellectExtra += 0.1 * intellect+51;
                multiplier += 0.1;
            }

            if ((bool)Gnome.IsChecked)
            {
                intellectExtra = intellectExtra * 1.05;
            }

            if ((bool)Netherwind.IsChecked)
            {

            }

            if ((bool)Talisman.IsChecked)
            {

            }

            if ((bool)MQG.IsChecked)
            {

            }

            if ((bool)HeroCharm.IsChecked)
            {

            }

            

            Math.Round(intellectExtra);
            double intCrit = intellectExtra / 59.5;
            crit_buff += intCrit;
            double spellPower = int.Parse(Spellpower.Text) + Bonus_Spellpower;
            double critical = (1 + (0.01 * ((double.Parse(Crit_Chance.Text))+crit_buff))) * (critical_multiplier / 2);
            double hit_chance = 0.89+(0.01* int.Parse(Hit_Chance.Text));
            double damage = (((max + min) / 2) + (spellPower * SP_Multiplier)) * multiplier * critical * hit_chance;
            double dps = (damage / time);

            double dpsMod1 = 0;
            double dpsMod2 = 0;
            double dpsMod3 = 0;
            double dpsMod = 0;
            if (((ComboBoxItem)Spec_Selection.SelectedItem).Content.ToString() == "Deep Fire")
            {
                if ((bool)Netherwind.IsChecked)
                {
                    dpsMod1 = (((890 + 716) / 2) + (spellPower * SP_Multiplier)) * multiplier * critical * hit_chance;
                    dpsMod2 = (268 + (spellPower * 0.175)) * hit_chance;
                    dpsMod = (dpsMod1 + dpsMod2) / 30;
                    dpsMod3 = damage / 60;
                }
            }

            if (((ComboBoxItem)Spec_Selection.SelectedItem).Content.ToString() == "Frost (Arcane Power)")
            {
                dpsMod1 = dps * 96.5;

                dpsMod2 = damage * 6 * 1.3;

                dps = (dpsMod1 + dpsMod2) / 110;

                if ((bool)Netherwind.IsChecked)
                {
                    dps = dps + (damage / 25 *4 /5 );
                }
            }



            dps += dpsMod;
            dps -= dpsMod3;

            Output.Text = dps.ToString();


        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
    }
}
