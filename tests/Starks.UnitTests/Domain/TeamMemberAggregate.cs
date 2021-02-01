//using System;
//using System.Collections.Generic;
//using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;
//using XPInc.Hackathon.Starks.Domain.Exceptions;
//using Xunit;

//namespace Starks.UnitTests.Domain
//{
//    public class TeamMemberAggregate
//    {
//        readonly Guid managerId = new Guid("a991a4a1-6bc0-482d-b384-e4887d36659d");
//        readonly TeamMember teamMember1;
//        readonly TeamMember teamMember2;
//        readonly TeamMember teamMember3;

//        public TeamMemberAggregate()
//        {
//            teamMember1 = new TeamMember("danilo.kawanishi@xpi.com.br", "Danilo", "Kawanishi", "11976255210", managerId);
//            teamMember2 = new TeamMember("jhones.goncalves@xpi.com.br", "Jhones", "Gonçalves", "11912345654", managerId,
//                failovers: new Dictionary<short, Guid>
//                {
//                    { 1, teamMember1.Id }
//                });
//            teamMember3 = new TeamMember("charles@xpi.com.br", "Charles", "Dias", "11977887788", managerId);
//        }

//        [Fact]
//        public void Create_team_member_without_manager()
//        {
//            Assert.Throws<DomainException>(() =>
//                new TeamMember(teamMember1.Email, teamMember1.Name, teamMember1.Surname, teamMember1.Phone, new Guid())
//            );
//        }

//        [Fact]
//        public void Create_team_member_with_manager()
//        {
//            TeamMember teamMember = 
//                new TeamMember(teamMember1.Email, teamMember1.Name, teamMember1.Surname, teamMember1.Phone, managerId);

//            Assert.NotNull(teamMember);
//            Assert.Equal(managerId, teamMember.ManagerId);
//        }

//        [Fact]
//        public void Create_team_member_with_failover_duplicated()
//        {
//            teamMember1.AddFailover(teamMember2.Id);
//            teamMember1.AddFailover(teamMember3.Id);

//            Assert.Throws<DomainException>(() =>
//            {
//                teamMember1.AddFailover(teamMember2.Id);
//            });
//        }

//        //[Fact]
//        //public void Get_failover_without_team_member()
//        //{
//        //    var teamMember = new TeamMember(
//        //        teamMember1.Email, teamMember1.Name, teamMember1.Surname, teamMember1.Phone, managerId);

//        //    Assert.Equal(managerId, teamMember.Failovers[1]);
//        //}
//    }
//}
