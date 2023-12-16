using btg_testes_auto.Notification;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace btg_test.NotificationEmailTest
{
    public class NotificationServiceTest
    {
        private readonly IEmailService _mockEmailService;
        private readonly NotificationService _sut;

        public NotificationServiceTest()
        {
            _mockEmailService = Substitute.For<IEmailService>();
            _sut = new NotificationService(_mockEmailService);
        }

        [Fact(DisplayName = "Null Message")]
        public void SendNotification_NullMessage_ReturnFalse()
        {
            bool result = _sut.SendNotification("recipient", null);

            result.Should().BeFalse();
            _mockEmailService.Received(0).SendEmail("recipient", "Notification", null);
        }

        [Fact(DisplayName = "Empty Message")]
        public void SendNotification_EmptyMessage_ReturnFalse()
        {
            bool result = _sut.SendNotification("recipient", "");

            result.Should().BeFalse();
            _mockEmailService.Received(0).SendEmail("recipient", "Notification", "");
        }

        [Fact(DisplayName = "Not Empty Message")]
        public void SendNotification_NotEmptyMessage_ReturnTrue()
        {
            _mockEmailService.SendEmail("recipient", "Notification", "This is a Message!").Returns(true);

            bool result = _sut.SendNotification("recipient", "This is a Message!");

            result.Should().BeTrue();
            _mockEmailService.Received(1).SendEmail("recipient", "Notification", "This is a Message!");
        }

        [Fact(DisplayName = "Throw Exception")]
        public void SendNotification_ThrowException_ReturnFalse()
        {
            _mockEmailService.SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Throws(new Exception());

            bool result = _sut.SendNotification("recipient", "This is a Message!");

            result.Should().BeFalse();
            _mockEmailService.Received(1).SendEmail("recipient", "Notification", "This is a Message!");
        }

    }
}
