
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAppTesting.DAL;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Enum;

namespace WebAppTesting.DAL
{
    public class DBObjects
    {
        public static void Initial(AppDBContext content)
        {


            if (!content.Users.Any())
            {
                content.Users.AddRange(Users.Select(c => c.Value));
            }

            content.SaveChanges();

            if (!content.Subjects.Any())
                content.Subjects.AddRange(Subjects.Select(c => c.Value));

            if (!content.Grades.Any())
            {
                content.Grades.AddRange(Grades.Select(c => c.Value));
            }

            if (!content.Testing.Any())
            {
                content.Testing.AddRange(Testings.Select(c => c.Value));
            }


            if (!content.Tests.Any())
            {
                content.Tests.AddRange(Tests.Select(c => c.Value));
            }


            if (!content.Answers.Any())
            {
                content.Answers.AddRange(Answers.Select(c => c.Value));
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Subjects> subject;
        public static Dictionary<string, Subjects> Subjects
        {
            get
            {
                if(subject == null)
                {
                    var list = new Subjects[]
                    {
                        new Subjects { Name = "Алгебра"},
                        new Subjects { Name = "Геометрія"},
                        new Subjects { Name = "Географія"},
                        new Subjects { Name = "Історія"},
                        new Subjects { Name = "Фізика"}
                    };

                    subject = new Dictionary<string, Subjects>();
                    foreach(Subjects el in list)
                    {
                        subject.Add(el.Name, el);
                    }
                }

                return subject;
            }
        }



        private static Dictionary<string, Grades> grade;
        public static Dictionary<string, Grades> Grades
        {
            get
            {
                if (grade == null)
                {
                    var list = new Grades[]
                    {
                        new Grades { Name = "1-ий клас" },
                        new Grades { Name = "2-ий клас" },
                        new Grades { Name = "3-ий клас" },
                        new Grades { Name = "4-ий клас" },
                        new Grades { Name = "5-ий клас" },
                        new Grades { Name = "6-ий клас" },
                        new Grades { Name = "7-ий клас" },
                        new Grades { Name = "8-ий клас" },
                        new Grades { Name = "9-ий клас" },
                        new Grades { Name = "10-ий клас" },
                        new Grades { Name = "11-ий клас" },
                        new Grades { Name = "2-ий курс" },
                        new Grades { Name = "3-ий курс" },
                        new Grades { Name = "4-ий курс" }
                    };

                    grade = new Dictionary<string, Grades>();
                    foreach (Grades el in list)
                    {
                        grade.Add(el.Name, el);
                    }
                }

                return grade;
            }
        }

        private static Dictionary<string, User> user;

        public static Dictionary<string, User> Users
        {
            get
            {
                if (user == null)
                {
                    var list = new User[]
                    {
                        new User { Name = "xkrayel", Password="16079cf6877ceb45aea98ab7d4745e3076fc8c31288ca407d2529b99cf6d0db2", Role = Role.Admin },
                        
                    };

                    user = new Dictionary<string, User>();
                    foreach (User el in list)
                    {
                        user.Add(el.Name, el);
                    }
                }

                return user;
            }
        }



        private static Dictionary<string, Testing> testing;

        public static Dictionary<string, Testing> Testings
        {
            get
            {
                if (testing == null)
                {
                    var list = new Testing[]
                    {
                        new Testing { Name = "Тестування з математики", User = Users["xkrayel"], Subject = Subjects["Алгебра"], Grade = Grades["2-ий клас"] },
                        new Testing { Name = "Тест з Географії", User = Users["xkrayel"], Subject = Subjects["Географія"] , Grade = Grades["9-ий клас"] }
                    };

                    testing = new Dictionary<string, Testing>();
                    foreach (Testing el in list)
                    {
                        testing.Add(el.Name, el);
                    }
                }

                return testing;
            }
        }


        private static Dictionary<string, Tests> test;
        public static Dictionary<string, Tests> Tests
        {
            get
            {
                if (test == null)
                {
                    var list = new Tests[]
                    {
                        new Tests { Testing = Testings["Тестування з математики"], ques = "2 + 2 = ?"},
                        new Tests { Testing = Testings["Тестування з математики"], ques = "10 - 2 = ?"},
                        new Tests { Testing = Testings["Тестування з математики"], ques = "4 - 2 = ?"},
                        new Tests { Testing = Testings["Тестування з математики"], ques = "7 * 5 = ?"},
                        new Tests { Testing = Testings["Тестування з математики"], ques = "10 / 2 = ?"},
                        new Tests { Testing = Testings["Тестування з математики"], ques = "0 - 0 = ?"},
                        new Tests { Testing = Testings["Тест з Географії"], ques = "Скільки існує материків?"},
                        new Tests { Testing = Testings["Тест з Географії"], ques = "Обери існуючі материки - "},
                        new Tests { Testing = Testings["Тест з Географії"], ques = "Столиця України?"},
                        new Tests { Testing = Testings["Тест з Географії"], ques = "Площа України"}
                    };

                    test = new Dictionary<string, Tests>();
                    foreach (Tests el in list)
                    {
                        test.Add(el.ques, el);
                    }
                }

                return test;
            }
        }

        private static Dictionary<string, Answers> answerr;
        public static Dictionary<string, Answers> Answers
        {
            get
            {
                if (answerr == null)
                {
                    var list = new Answers[]
                    {
                        new Answers { Test = Tests["2 + 2 = ?"], answer = "1", isTrue=false},
                        new Answers { Test = Tests["2 + 2 = ?"], answer = "2", isTrue=false},
                        new Answers { Test = Tests["2 + 2 = ?"], answer = "3", isTrue=false},
                        new Answers { Test = Tests["2 + 2 = ?"], answer = "4", isTrue=true},
                        new Answers { Test = Tests["2 + 2 = ?"], answer = "5", isTrue=false},
                        new Answers { Test = Tests["2 + 2 = ?"], answer = "6", isTrue=false},

                        new Answers { Test = Tests["Скільки існує материків?"], answer = "Один", isTrue=false},
                        new Answers { Test = Tests["Скільки існує материків?"], answer = "Три", isTrue=false},
                        new Answers { Test = Tests["Скільки існує материків?"], answer = "П'ять", isTrue=false},
                        new Answers { Test = Tests["Скільки існує материків?"], answer = "Шість", isTrue=false},
                        new Answers { Test = Tests["Скільки існує материків?"], answer = "Сім", isTrue=true},
                        new Answers { Test = Tests["Скільки існує материків?"], answer = "Вісім", isTrue=false},
                        new Answers { Test = Tests["Скільки існує материків?"], answer = "Дев'ять", isTrue=false}


                    };

                    answerr = new Dictionary<string, Answers>();
                    foreach (Answers el in list)
                    {
                        answerr.Add(el.answer, el);
                    }
                }

                return answerr;
            }
        }
    }
}
