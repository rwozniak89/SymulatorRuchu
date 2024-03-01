using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unit1.Support;

namespace Unit1
{
    public partial class StartForm : Form
    {
        CarPark _CarPark;
        CarPark _CarParkClone;

        public StartForm()
        {
            InitializeComponent();

            _CarPark = new CarPark(3);
            _RegistartionNumber_TextBox.Text = "WL52467";
            _Mark_TextBox.Text = "Ford";
            _CarsParkMax_TextBox.Text = _CarPark.Max.ToString();
            _CarsParkState_TextBox.Text = _CarPark.Count.ToString();
            _CarPark.CarParkEvent += _CarPark_CarParkEvent;
        }

        private void _Clear_Button_Click(object sender, EventArgs e)
        {
            _Info_TextBox.Clear();
        }

        void WriteInfo(string info)
        {
            List<string> infoList = _Info_TextBox.Lines.ToList();

            infoList.Add(info);
            _Info_TextBox.Lines = infoList.ToArray();
        }

        private void _ClassCreate_Button_Click(object sender, EventArgs e)
        {
            Car car = new Car();

            WriteInfo(car.ToString());
        }

        private void _CreateClassInternal_Button_Click(object sender, EventArgs e)
        {
            //Calculations calculations = new Calculations();
        }

        private void _CreateClassPrivateConstructor_Button_Click(object sender, EventArgs e)
        {
            //Calculations2 calculations = new Calculations2();
            //Calculations3 calculations = new Calculations3();
        }

        private void _CreateClassBaseThis_Button_Click(object sender, EventArgs e)
        {
            Fish fish = new Fish("Karp");
            Fish fish2 = new Fish("Dorsz", false);

            WriteInfo(fish.ToString());
            WriteInfo(fish2.ToString(true));
        }

        private void _CalcOnBits_Button_Click(object sender, EventArgs e)
        {
            BitsOper bitsOper = new BitsOper(0b01110111);

            bitsOper[3] = true;
            WriteInfo($"{bitsOper}");
        }

        private void _RegistartionNumeberAdd_Button_Click(object sender, EventArgs e)
        {
            string registartionNumber = _RegistartionNumber_TextBox.Text;
            string mark = _Mark_TextBox.Text;

            if (!string.IsNullOrEmpty(registartionNumber) && !string.IsNullOrEmpty(mark))
            {
                if (_CarPark[registartionNumber] != null)
                    MessageBox.Show(string.Format("Pojazd o numerze {0} już istnieje.", registartionNumber), "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (_CarPark.AddCar(registartionNumber, mark))
                    {
                        _CarsParkState_TextBox.Text = _CarPark.Count.ToString();
                    }
                }
            }
        }

        private void _RegistrationNumberRemove_Button_Click(object sender, EventArgs e)
        {
            string registartionNumber = _RegistartionNumber_TextBox.Text;

            if (!string.IsNullOrEmpty(registartionNumber))
            {
                if (_CarPark[registartionNumber] != null)
                {
                    if (_CarPark.RemoveCar(registartionNumber))
                        _CarsParkState_TextBox.Text = _CarPark.Count.ToString();
                }
            }
            else
                MessageBox.Show(string.Format("Pojazd o numerze {0} nie istnieje.", registartionNumber), "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void _Modify_Button_Click(object sender, EventArgs e)
        {
            string registartionNumber = _RegistartionNumber_TextBox.Text;
            string mark = _Mark_TextBox.Text;

            if (!string.IsNullOrEmpty(registartionNumber) && !string.IsNullOrEmpty(mark))
            {
                Car car = _CarPark[registartionNumber];

                if(car != null)
                    car.Mark = mark;
            }
        }

        private void _CarPark_CarParkEvent(object sender, CarParkEventArgs e)
        {
            switch (e.ParkEvent)
            {
                case En_ParkEvent.CarAdded:
                    WriteInfo(string.Format("Dodano pojazd o numerze {0}", e.Car.RegistrationNumber));
                    break;
                case En_ParkEvent.CarRemoved:
                    WriteInfo(string.Format("Usunięto pojazd o numerze {0}", e.Car.RegistrationNumber));
                    break;
                case En_ParkEvent.CarParkFull:
                    WriteInfo("Parking jest pełny");
                    break;
            }
        }

        private void _ShallowClone_Button_Click(object sender, EventArgs e)
        {
            _CarParkClone = _CarPark.CloneShallow() as CarPark;

            if(_CarParkClone != null)
            {
                string info = string.Format("Po sklonowaniu płytkim na parkingu jest {0} pojazdów.", _CarParkClone.Count);

                WriteInfo(info);
            }
        }

        private void _DeepClone_Button_Click(object sender, EventArgs e)
        {
            _CarParkClone = _CarPark.Clone(true) as CarPark;

            if (_CarParkClone != null)
            {
                string info = string.Format("Po sklonowaniu głębokim na parkingu jest {0} pojazdów.", _CarParkClone.Count);

                WriteInfo(info);
            }
            /*

            CarPark2 carPark2 = new CarPark2();

            carPark2.AddCar(new Car("aa", "f", 10));
            carPark2.AddCar(new Car("aab", "f", 10));
            
            CarPark2 carPark21 = (CarPark2)carPark2.Clone();

            CarPark carPark = new CarPark();

            carPark.AddCar(new Car("aa", "f", 10));
            carPark.AddCar(new Car("aab", "f", 10));
            ;
            CarPark carPark1 = (CarPark)carPark.Clone(true);

            CarPark carPark12= (CarPark)_CarPark.Clone(true);
            */
        }
        private void comparePark()
        {
            bool result = _CarPark.compareCarPark(_CarParkClone);
            if (result)
            {
                WriteInfo(string.Format("Porównano Parki, wynik: takie same"));
            }
            else
                WriteInfo(string.Format("Porównano Parki, wynik: różne"));
        }
        private void _CloneCheck_Button_Click(object sender, EventArgs e)
        {
            if (_CarParkClone != null)
            {
                string registartionNumber = _RegistartionNumber_TextBox.Text;

                if (!string.IsNullOrEmpty(registartionNumber))
                {
                    Car car = _CarPark[registartionNumber];
                    Car carCloned = _CarParkClone[registartionNumber];
                    string info = string.Format("Marka samochodu o rejestracji {0}: oryginalnego {1}, skonowanego {2}", registartionNumber,
                                                                                                            car != null ? car.Mark : "",
                                                                                                            carCloned != null ? carCloned.Mark : "");
                    WriteInfo(info);
                }

                comparePark();
            }
            else
                MessageBox.Show("Sklonuj najpierw.");


            

        }

        private void _Compare_Button_Click(object sender, EventArgs e)
        {
            if (_CarParkClone != null)
            {
                string registartionNumber = _RegistartionNumber_TextBox.Text;

                if (!string.IsNullOrEmpty(registartionNumber))
                {
                    Car car = _CarPark[registartionNumber];
                    Car carCloned = _CarParkClone[registartionNumber];
                    // Do testów oba obiekty muszą istnieć.
                    if (car == null)
                        MessageBox.Show(string.Format("Nie ma pojazdu o numerze {0}", registartionNumber));
                    else if (carCloned == null)
                        MessageBox.Show(string.Format("Nie ma pojazdu sklonowanego o numerze {0}", registartionNumber));
                    else
                    {
                        bool bIsEqualByReference = Object.ReferenceEquals(car, carCloned); // referencje będą różne jeśli będzie klonowanie głębokie.
                        bool bIsEqual = car.Equals(carCloned);
                        string info = string.Format("Marka samochodu o rejestracji {0}: oryginalnego {1}, skonowanego {2}, referencje te same = {3}, Equal = {4}", registartionNumber,
                                                                                                                car.Mark, carCloned.Mark,
                                                                                                                bIsEqualByReference, bIsEqual);
                        _IsReferenceEqual_CheckBox.Checked = bIsEqualByReference;
                        _IsEqual_CheckBox.Checked = bIsEqual;
                        _MarkOryginal_TextBox.Text = car.Mark;
                        _MarkCloned_TextBox.Text = carCloned.Mark;

                        WriteInfo(info);
                        comparePark();
                    }
                }
            }
            else
                MessageBox.Show("Sklonuj najpierw.");
        }

       

        private void _Draw_Button_Click(object sender, EventArgs e)
        {
            //////////////////
            /// Pokaz obsługi masowej.
            int iCount = 100;
            List<Drawable> drawableList = new List<Drawable>();

            for(int i = 0; i< iCount; i++)
            {
                drawableList.Add(new Drawable());
            }

            foreach(Drawable drawable in drawableList)
            {
                drawable.Dispose();
            }

            drawableList.Clear();

            // Pokaz użycia pojedynczego poprzez using.
            using (Drawable dr = new Drawable())
            {
                dr.Draw();
            }
        }

        private void _SetState_Button_Click(object sender, EventArgs e)
        {
            _CarPark.GetState(out string name, out int iCount);
            _ParkingName_TextBox.Text = name;
            _ParkingCount_TextBox.Text = iCount.ToString();
        }

        private void _SetState_Button_Click_1(object sender, EventArgs e)
        {
            string name = _ParkingName_TextBox.Text;

            _CarPark.SetState(ref name);
            _ParkingName_TextBox.Text = name;
        }

        private void _CreateClassProtected_Button_Click(object sender, EventArgs e)
        {
            AnimalExtend animalExtend = new AnimalExtend("Zwierzę 'extendes'");

            WriteInfo(animalExtend.ToString());
        }

        class AnimalExtend : Animal
        {
            ProtectedAnimalEx _ProtectedAnimalEx = new ProtectedAnimalEx();
            InternalProtectedAnimalEx _InternalProtectedAnimalEx = new InternalProtectedAnimalEx();

            public AnimalExtend(string name) : base(name, true)
            {

            }

            class ProtectedAnimalEx : ProtectedAnimal
            {

            }

            /*
            class PrivateAnimalEx : PrivateAnimal
            {

            }
            */

            class InternalProtectedAnimalEx : InternalProtectedAnimal
            {

            }

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}", this.Name, _ProtectedAnimalEx.ToString(), _InternalProtectedAnimalEx.ToString());
            }
        }

        private void _InheritanceByAnimal_Button_Click(object sender, EventArgs e)
        {
            Fish fish = new Fish("Karp");

            WriteInfo(fish.ToString(true));

            Mammal mammal = new Mammal("Pies");

            WriteInfo(mammal.ToString());
        }

        /*
        sealed class SealedAnimal : Animal
        {
            public SealedAnimal(string name) : base(name, true)
            {

            }
        }

        class SealedAnimalEx : SealedAnimal
        {
            public SealedAnimalEx(string name) : base(name, true)
            {

            }
        }
        */

        private void _CreateClassBySealed_Button_Click(object sender, EventArgs e)
        {
            /*
            SealedAnimalEx sealedAnimalEx = new SealedAnimalEx("Test");

            WriteInfo(sealedAnimalEx.ToString());
            */
        }

        private void _Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _MtehodModifiers_Button_Click(object sender, EventArgs e)
        {
            Fish fish = new Fish("Karp");

            WriteInfo(fish.GetVertebratesDescr());
        }

        private void _CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _VecCalc_Button_Click(object sender, EventArgs e)
        {
            try
            {
                double dAngle = Convert.ToDouble(_VecAngle_TextBox.Text);

                SizeF vec = Unit2.Support.Calculations.GetVecFromAngle2(dAngle);

                _VecX_TextBox.Text = vec.Width.ToString();
                _VecY_TextBox.Text = vec.Height.ToString();
            }
            catch { }
        }

        private void _VecCalcTest_Button_Click(object sender, EventArgs e)
        {
            SizeF vec1, vec2;

            for(int i=0; i<360; i++)
            {
                vec1 = Unit2.Support.Calculations.GetVecFromAngle(i);
                vec2 = Unit2.Support.Calculations.GetVecFromAngle2(i);

                if(vec1.Width != vec2.Width || vec1.Height != vec2.Height)
                {
                    Console.WriteLine("Błąd dla {0}", i);
                }
            }
        }
    }
}
