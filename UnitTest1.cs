using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using to_do_itv2.Data;
using to_do_itv2.Models;
using Xunit.Sdk;

namespace to_do_itv2.Tests
{
    public class ToDoItV2Tests
    {
        [Fact]
        public void Person_ShouldShow()
        {
            PersonSequencer.Reset();
            Person p1 = new Person(0, "Vestelind", "Alex");
            string expected = "0 Vestelind Alex"; //Arrange
            string actual = p1.PersonId.ToString() + " " + p1.LastName + " " + p1.FirstName; //Act
            Assert.Equal(expected, actual); //Assert
        }
        [Fact]
        public void ToDo_ShouldShow()
        {
            TodoSequencer.Reset();
            ToDo t1 = new ToDo(TodoSequencer.NextToDoId(), "do chores", true);
            string expected =  "0 do chores";
            string actual = t1.Id.ToString() + " " + t1.Description;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PersonSequencer_personIdTest()
        {
            TodoSequencer.Reset();
            Person p1 = new Person(0, "Vestelind", "Alex");
            Person p2 = new Person(1, "Vestelind", "Max");
            int expected = 0;
            int actual = PersonSequencer.NextPersonId();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToDoSequencer_toDoIdTest()
        {
            TodoSequencer.Reset();
            ToDo t1 = new ToDo(TodoSequencer.NextToDoId(), "chores", false);
            ToDo t2 = new ToDo(TodoSequencer.NextToDoId(), "code", false);
            int expected = 2;
            int actual = TodoSequencer.NextToDoId();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PeopleService_ArrayPeopleCountTest()
        {
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();
            Person p = peopleService.NewPerson("Alex", "Vestelind");
            int expected = 1;
            int actual = peopleService.peopleCount;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PeopleService_ArrayPersonTest2()
        {
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();
            Person p = peopleService.NewPerson("Alex", "Vestelind");
            Person expected = p;
            Person actual = peopleService.People[0];
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToDoService_ArrayTest()
        {
            ToDoService toDoService = new ToDoService();
            toDoService.Clear();
            ToDo t = toDoService.NewToDo("clean dishes", false);
            int expected = 1;
            int actual = toDoService.toDoCount;
            Assert.Equal(expected, actual);
            ToDo expectedt = t;
            ToDo actualt = toDoService.ToDoArray[0];
            Assert.Equal(expectedt, actualt);
        }
        [Fact]
        public void ToDoService_SearchTest()
        {
            Person p = new Person(PersonSequencer.NextPersonId(), "Vestelind", "Alex");
            ToDoService t1 = new ToDoService();
            t1.Clear();
            t1.NewToDo("clean", false, p);
            t1.NewToDo("dishes", true);
            int actual = t1.toDoCount;
            int expected = 2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PeopleService_FindAllTest()
        {
                //Arrange            
                PeopleService peopleService = new PeopleService();
                peopleService.Clear();



                peopleService.NewPerson("Janne", "Lindberg");
                peopleService.NewPerson("Anna", "Salin");
                peopleService.NewPerson("Jonas", "Schmidth");
                int expectedSize = 3;
                //Act
                Person[] foundPeople = peopleService.FindAll();



                //Assert
                Assert.Equal(expectedSize, foundPeople.Length); 
        }
        [Fact]
        public void PeopleService_RemovePersonTest()
        {
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();

            peopleService.NewPerson("Janne", "Lindberg");
            peopleService.NewPerson("Anna", "Salin");
            peopleService.NewPerson("Jonas", "Schmidth");

            peopleService.RemovePerson(2);
            int expectedSize = 2;
            Person[] foundPeople = peopleService.FindAll();
            Assert.Equal(expectedSize, foundPeople.Length);
        }
        [Fact]
        public void ToDoService_RemoveItemTest()
        {
            ToDoService toDoService = new ToDoService();
            Person p = new Person(0, "", "");
            toDoService.Clear();

            toDoService.NewToDo("clean", false, p);
            toDoService.NewToDo("shop", true);
            toDoService.NewToDo("work", true, p);
            toDoService.NewToDo("work", true, p);

            toDoService.RemoveItem(3);
            int expectedSize = 3;
            ToDo[] foundToDos = toDoService.FindAll();
            Assert.Equal(expectedSize, foundToDos.Length);
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FirstNameBadValueTest(string badFirstName)
        {
            //Arrange

            Person testPerson = new Person(PersonSequencer.NextPersonId(), "Jonna", "Lind");

            //Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => testPerson.FirstName = badFirstName);

            //Assert
            Assert.Contains("First name must contain at least 2 letters", exception.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void LastNameBadValueTest(string badLastName)
        {
            //Arrange
            Person testPerson = new Person(PersonSequencer.NextPersonId(), "Sam", "Jonsson");

            //Act
            var exception = Assert.Throws<ArgumentException>(() => testPerson.LastName = badLastName);

            //Assert
            Assert.Contains("Last name must contain at least 2 letters", exception.Message);
        }
        [Fact]
        public void PersonClassTest()
        {
            // Arrange
            string firstName1 = "Susy";
            string lastName1 = "Lund";
            string firstName2 = "Melwin";
            string lastName2 = "Carlsson";


            // Act
            Person testPerson1 = new Person(PersonSequencer.NextPersonId(), lastName1, firstName1);
            Person testPerson2 = new Person(PersonSequencer.NextPersonId(), lastName2, firstName2);

            // Assert        
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);
            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);
        }
        [Fact]
        public void TodoClassTest()
        {
            //Arrange
            string description1 = "Finish assignment";
            string description2 = "Go for walk";

            //Act
            ToDo testTodo1 = new ToDo(TodoSequencer.NextToDoId(), description1);
            ToDo testTodo2 = new ToDo(TodoSequencer.NextToDoId(), description2);

            //Assert

            Assert.Equal(description1, testTodo1.Description);
            Assert.Equal(description2, testTodo2.Description);
        }
        [Fact]
        public void ResetPersonIdTest()
        {

            //Arrange
            PersonSequencer.Reset();
            int expected = 0;
            int actual;
            actual = PersonSequencer.PersonId;

            //Act
            PersonSequencer.PersonId = 5;

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NextPersonIdTest()
        {
            //Arrange
            int expectedId1 = 0;
            int expectedId2 = 1;
            int id1;
            int id2;
            PersonSequencer.Reset();
            //Act
            id1 = PersonSequencer.NextPersonId();
            id2 = PersonSequencer.NextPersonId();


            //Assert
            Assert.Equal(expectedId1, id1);
            Assert.Equal(expectedId2, id2);
        }
        [Fact]
        public void ResetTodoIdTest()
        {
            //Arrange
            int expected = 0;
            TodoSequencer.ToDoId = 4;

            //Act
            TodoSequencer.Reset();


            //Assert
            Assert.Equal(expected, TodoSequencer.ToDoId);
        }
        [Fact]
        public void NextTodoIdTest()
        {

            //Arrange
            int expectedId1 = 0;
            int expectedId2 = 1;
            int id1;
            int id2;
            TodoSequencer.Reset();
            //Act
            id1 = TodoSequencer.NextToDoId();
            id2 = TodoSequencer.NextToDoId();


            //Assert
            Assert.Equal(expectedId1, id1);
            Assert.Equal(expectedId2, id2);
        }
        [Fact]

        public void CreateNewPersonTest()
        {
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();
            string firstName1 = "Hanna";
            string lastName1 = "Ljung";
            string firstName2 = "Mona";
            string lastName2 = "Lund";


            //Act
            Person testPerson1 = testingPeople.NewPerson(firstName1, lastName1);
            Person testPerson2 = testingPeople.NewPerson(firstName2, lastName2);

            //Assert
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);

            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);

        }
        [Fact]
        public void FindPersonByIdTest()
        {
            //Arrange
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();
            Person testPerson1 = testingPeople.NewPerson("Fred", "Lindberg");
            Person testPerson2 = testingPeople.NewPerson("Anna", "Molin");
            Person testPerson3 = testingPeople.NewPerson("Jens", "Schmidth");
            int checkedPersonId = testPerson2.PersonId;

            //Act
            Person matchedPerson = testingPeople.FindById(checkedPersonId);

            //Assert
            Assert.NotEqual(matchedPerson, testPerson1);
            Assert.Equal(matchedPerson, testPerson2);
            Assert.NotEqual(matchedPerson, testPerson3);
        }
        [Fact]
        public void SizePersonTest()
        {
            //Assert
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();
            testingPeople.NewPerson("Hanna", "Ljung");
            testingPeople.NewPerson("Mona", "Lund");

            int expectedSize = 2;

            //Act
            int actualSize = testingPeople.Size();

            //Assert
            Assert.Equal(expectedSize, actualSize);
        }
        [Fact]
        public void FindAllPeopleTest()
        {
            //Arrange            
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();

            testingPeople.NewPerson("Fred", "Lindberg");
            testingPeople.NewPerson("Anna", "Molin");
            testingPeople.NewPerson("Jens", "Schmidth");
            int expectedSize = 3;
            //Act
            Person[] foundPersons = testingPeople.FindAll();

            //Assert
            Assert.Equal(expectedSize, foundPersons.Length);
        }
        [Fact]
        public void RemovePersonTest()
        {
            //Arrange
            PeopleService testPerson = new PeopleService();
            testPerson.Clear();
            Person testPerson1 = testPerson.NewPerson("Maja", "Ljung");
            Person testPerson2 = testPerson.NewPerson("Ludwig", "Hallberg");
            Person testPerson3 = testPerson.NewPerson("Anna", "Larsson");


            //Act
            testPerson.RemovePerson(testPerson2.PersonId);

            //Assert
            Assert.Contains(testPerson1, testPerson.FindAll());
            Assert.DoesNotContain(testPerson2, testPerson.FindAll());
            Assert.Contains(testPerson3, testPerson.FindAll());
        }
        [Fact]
        public void CreateNewTodoTest()
        {
            //Arrange
            ToDoService testingTodo = new ToDoService();
            testingTodo.Clear();

            string description1 = "Study";
            string description2 = "Exercise";
            string description3 = "Cook";


            //Act
            ToDo testPerson1 = testingTodo.NewToDo(description1);
            ToDo testPerson2 = testingTodo.NewToDo(description2);
            ToDo testPerson3 = testingTodo.NewToDo(description3);

            //Assert
            Assert.Equal(description1, testPerson1.Description);
            Assert.Equal(description2, testPerson2.Description);
            Assert.Equal(description3, testPerson3.Description);
        }
        [Fact]

        public void FindTodoByIdTest()
        {
            //Arrange
            ToDoService testingTodos = new ToDoService();
            testingTodos.Clear();
            ToDo testTodo1 = testingTodos.NewToDo("Read");
            ToDo testTodo2 = testingTodos.NewToDo("Go swimming");
            ToDo testTodo3 = testingTodos.NewToDo("Finish assignment");
            int checkedTodoId = testTodo3.Id;

            //Act
            ToDo matchedTodo = testingTodos.FindById(checkedTodoId);

            //Assert
            Assert.NotEqual(matchedTodo, testTodo2);
            Assert.NotEqual(matchedTodo, testTodo2);
            Assert.Equal(matchedTodo, testTodo3);

        }
        [Fact]
        public void ToDoSizeTest()
        {
            //Assert

            ToDoService testingToDos = new ToDoService();
            testingToDos.Clear();
            testingToDos.NewToDo("clean");
            testingToDos.NewToDo("shower");

            int expectedSize = 2;

            //Act
            int actualSize = testingToDos.Size();

            //Assert
            Assert.Equal(expectedSize, actualSize);
        }
        [Fact]
        public void FindByDoneTest()
        {
            //Arrange
            ToDoService todoTest = new ToDoService();
            todoTest.Clear();

            ToDo todo1 = todoTest.NewToDo("Go running");
            ToDo todo2 = todoTest.NewToDo("Relax");
            ToDo todo3 = todoTest.NewToDo("Finish Assignment");

            todoTest.FindById(todo1.Id).Done = true;
            todoTest.FindById(todo2.Id).Done = false;
            todoTest.FindById(todo3.Id).Done = true;

            //Act
            ToDo[] findDones = todoTest.FindByDoneStatus(true);

            //Assert
            for (int i = 0; i < findDones.Length; i++)
            {
                Assert.True(findDones[i].Done);
            }

            Assert.Contains(todo1, findDones);
            Assert.Contains(todo3, findDones);

        }
        [Fact]
        public void TestFindByAssigneeId()
        {
            //Arrange
            PersonSequencer.Reset();
            int personId = PersonSequencer.NextPersonId();

            Person assignee = new Person(personId, "Johnsson", "Fred");
            
            ToDoService testTodos = new ToDoService();
            testTodos.Clear();

            ToDo todo1 = testTodos.NewToDo("Go for a run");
            ToDo todo2 = testTodos.NewToDo("Sleep");
            ToDo todo3 = testTodos.NewToDo("Finish the test");
            ToDo todo4 = testTodos.NewToDo("Watch TV");

            todo1.Assignee = assignee;
            todo2.Assignee = assignee;

            //Act
            ToDo[] findAssigneeArray = testTodos.FindByAssignee(personId);

            //Assert
            Assert.Contains(todo1, findAssigneeArray);
            Assert.Contains(todo2, findAssigneeArray);
            Assert.DoesNotContain(todo3, findAssigneeArray);
            Assert.DoesNotContain(todo4, findAssigneeArray);

        }
        [Fact]
        public void FindByAssigneePersonTest()
        {
            //Arrange
            int personId = PersonSequencer.NextPersonId();
            string firstName1 = "Fred";
            string lastName1 = "Johnsson";
            string firstName2 = "Edwin";
            string lastName2 = "Nylén";

            Person assignee1 = new Person(personId, lastName1, firstName1);
            Person expectedAssignee = new Person(personId, lastName2, firstName2);

            ToDoService testTodos = new ToDoService();
            testTodos.Clear();


            ToDo todo1 = testTodos.NewToDo("Go for a run");
            ToDo todo2 = testTodos.NewToDo("Sleep");
            ToDo todo3 = testTodos.NewToDo("Finish the test");

            todo1.Assignee = assignee1;
            todo2.Assignee = expectedAssignee;
            todo3.Assignee = expectedAssignee;

            //Act
            ToDo[] findAssigneeArray = testTodos.FindByAssignee(expectedAssignee);

            //Assert
            Assert.Contains(todo2, findAssigneeArray);
            Assert.Contains(todo3, findAssigneeArray);
            Assert.DoesNotContain(todo1, findAssigneeArray);
        }
        [Fact]
        public void FindUnassignedTodoTest()
        {
            //Arrange
            PersonSequencer.Reset();
            Person testPerson = new Person(PersonSequencer.NextPersonId(), "Svensson", "Lotta");
            ToDoService testTodos = new ToDoService();
            testTodos.Clear();
            ToDo todo1 = testTodos.NewToDo("Have a rest");
            ToDo todo2 = testTodos.NewToDo("Eat");
            ToDo todo3 = testTodos.NewToDo("Work");
            ToDo todo4 = testTodos.NewToDo("Study");
            todo1.Assignee = testPerson;
            todo3.Assignee = testPerson;

            //Act
            ToDo[] unassignedTodos = testTodos.FindUnassignedTodoItems();

            //Assert
            Assert.Contains(todo2, unassignedTodos);
            Assert.Contains(todo4, unassignedTodos);
            Assert.DoesNotContain(todo1, unassignedTodos);
            Assert.DoesNotContain(todo3, unassignedTodos);
        }
        [Fact]
        public void RemoveTodoTest()
        {
            //Arrange
            ToDoService testTodo = new ToDoService();
            testTodo.Clear();

            ToDo todo1 = testTodo.NewToDo("Eat");
            ToDo todo2 = testTodo.NewToDo("Sleap");
            ToDo todo3 = testTodo.NewToDo("Run");

            //Act
            testTodo.RemoveItem(todo1.Id);

            //Assert
            Assert.Contains(todo2, testTodo.FindAll());
            Assert.Contains(todo3, testTodo.FindAll());
            Assert.DoesNotContain(todo1, testTodo.FindAll());
        }
    }
}