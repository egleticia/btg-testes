using btg_testes_auto.NotificationMessage;
using FluentAssertions;
using NSubstitute;

namespace btg_test.NotificationMessageTest
{
    public class NotificationMessageServiceTest
    {
        private readonly IMessageService _mockMessageService;
        private readonly NotificationService _sut;

        public NotificationMessageServiceTest()
        {
            _mockMessageService = Substitute.For<IMessageService>();
            _sut = new NotificationService(_mockMessageService);
        }

        [Fact(DisplayName = "All Message send")]
        public void NotifyUsers_AllMessageSend_ReturnTrue()
        {
            Notification notification = new Notification() { Message = "This is a Message!", UserId = "001" };
            List<Notification> notifications = new() { notification, notification };

            _mockMessageService.SendMessage("001", "This is a Message!")
                .Returns(true);

            bool result = _sut.NotifyUsers(notifications);

            result.Should().BeTrue();
            _mockMessageService.Received(2).SendMessage("001", "This is a Message!");
        }

        [Fact(DisplayName = "No Message Send")]
        public void NotifyUsers_NoMessageSend_ReturnFalse()
        {
            Notification notification1 = new Notification() { Message = "This is a Message!", UserId = "001" };
            Notification notification2 = new Notification() { Message = "This is a Message!", UserId = "002" };
            Notification notification3 = new Notification() { Message = "This is a Message!", UserId = "003" };

            List<Notification> notificationMessages = new() { notification1, notification2, notification3 };

            _mockMessageService.SendMessage("001", "This is a Message!").Returns(true);
            _mockMessageService.SendMessage("002", "This is a Message!").Returns(false);
            _mockMessageService.SendMessage("002", "This is a Message!").Returns(true);

            bool result = _sut.NotifyUsers(notificationMessages);

            result.Should().BeFalse();
            _mockMessageService.Received(1).SendMessage("001", "This is a Message!");
            _mockMessageService.Received(1).SendMessage("002", "This is a Message!");
            _mockMessageService.Received(1).SendMessage("003", "This is a Message!");
        }


    }
}
