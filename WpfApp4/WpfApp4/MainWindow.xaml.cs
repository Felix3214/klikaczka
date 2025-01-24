using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
       
        internal enum EducationLevel
        {
            podstawowe = 0,
            srednie = 1,
            wyzsze = 2,
        }


        internal class Person
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public EducationLevel Education { get; set; } = EducationLevel.podstawowe;

            public Person() { }
            public Person(string firstName, string lastName, EducationLevel education)
            {
                FirstName = firstName;
                LastName = lastName;
                Education = education;
            }

            public override string ToString()
            {
                return FirstName + " " + LastName + " " + Education.ToString();
            }
        }


        internal class ListOfPersons
        {
            public ObservableCollection<Person> persons;

            public ListOfPersons()
            {
                persons = new ObservableCollection<Person>();
                LoadPersons();
            }

            public void AddPerson(Person person)
            {
                persons.Add(person);
            }

            public void RemovePerson(Person person)
            {
                persons.Remove(person);
            }

            public void EditPerson(int index, Person person)
            {
                if (index >= 0 && index < persons.Count)
                {
                    persons[index] = person;
                }
            }

            public void RemovePersonAt(int index)
            {
                if (index >= 0 && index < persons.Count)
                {
                    persons.RemoveAt(index);
                }
            }

            public void LoadPersons()
            {
             
                persons.Add(new Person("Adam", "Kowalski", EducationLevel.srednie));
                persons.Add(new Person("Monika", "Dudek", EducationLevel.podstawowe));
                persons.Add(new Person("Jan", "Sobieski", EducationLevel.srednie));
                persons.Add(new Person("Anna", "Nowak", EducationLevel.wyzsze));
            }
        }


        ListOfPersons pList = new ListOfPersons();

        public MainWindow()
        {
            InitializeComponent();
          
            pListBox.ItemsSource = pList.persons; 
        }

  
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            EducationLevel edu = EducationLevel.podstawowe;
            if (education.SelectedItem != null)
                edu = (EducationLevel)education.SelectedIndex;

            pList.AddPerson(new Person(fName.Text, lName.Text, edu));

            fName.Clear();
            lName.Clear();
            education.SelectedIndex = -1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pListBox.SelectedIndex != -1)
            {
            
                pList.RemovePersonAt(pListBox.SelectedIndex);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (pListBox.SelectedIndex != -1)
            {
                Person selectedPerson = pList.persons[pListBox.SelectedIndex];

       
                selectedPerson.FirstName = fName.Text;
                selectedPerson.LastName = lName.Text;

   
                pList.EditPerson(pListBox.SelectedIndex, selectedPerson);

            
                fName.Clear();
                lName.Clear();
                education.SelectedIndex = -1;
            }
        }
    }
}
