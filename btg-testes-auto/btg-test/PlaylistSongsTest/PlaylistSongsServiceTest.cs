using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;

namespace btg_test.PlaylistSongsTest
{
    public class PlaylistSongsServiceTest
    {
        private readonly IPlaylistValidationService _mockPlaylistValidationService;
        private PlaylistService _sut;

        public PlaylistSongsServiceTest()
        {
            _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
            _sut = new(_mockPlaylistValidationService);
        }

        Song firstSong = new Song() { Artist = "firstArtist", Title = "firstTitle" };
        Song secondSong = new Song() { Artist = "secondArtist", Title = "secondTitle" };
        Song thirdSong = new Song() { Artist = "thirdArtist", Title = "thirdTitle" };
        Song fourthSong = new Song() { Artist = "fourthArtist", Title = "fourthTitle" };

        [Fact(DisplayName = "Not Valid Playlist")]
        public void AddSongsToPlaylist_NotValidPlaylist_ReturnFalse()
        {
            List<Song> songs = new List<Song>() { firstSong, secondSong, thirdSong };
            Playlist playlist = new Playlist() { MaxSongs = 3, Songs = songs };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, fourthSong)
                .Returns(false);

            bool result = _sut.AddSongToPlaylist(playlist, fourthSong);

            result.Should().BeFalse();
            _mockPlaylistValidationService.Received().CanAddSongToPlaylist(playlist, fourthSong);
            playlist.Songs.Should().Contain(firstSong);
            playlist.Songs.Should().Contain(secondSong);
            playlist.Songs.Should().Contain(thirdSong);
            playlist.Songs.Should().NotContain(fourthSong);
        }

        [Fact(DisplayName = "Valid Playlist")]
        public void AddSongsToPlaylist_ValidPlaylist_ReturnTrue()
        {
            List<Song> songs = new List<Song>() { firstSong, secondSong, thirdSong };
            Playlist playlist = new Playlist() { MaxSongs = 4, Songs = songs };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, fourthSong)
                .Returns(true);

            bool result = _sut.AddSongToPlaylist(playlist, fourthSong);

            result.Should().BeTrue();
            _mockPlaylistValidationService.Received().CanAddSongToPlaylist(playlist, fourthSong);
            playlist.Songs.Should().Contain(firstSong);
            playlist.Songs.Should().Contain(secondSong);
            playlist.Songs.Should().Contain(thirdSong);
            playlist.Songs.Should().Contain(fourthSong);

        }

        [Fact(DisplayName = "Not Valid Playlist with Songs List")]
        public void AddSongsToPlaylist_NotValidPlaylistWithList_ReturnFalse()
        {
            List<Song> songs = new List<Song>() { firstSong, secondSong, thirdSong };
            Playlist playlist = new Playlist() { MaxSongs = 3, Songs = songs };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, fourthSong)
                .Returns(false);

            bool result = _sut.AddSongToPlaylist(playlist, fourthSong);

            result.Should().BeFalse();
            _mockPlaylistValidationService.Received().CanAddSongToPlaylist(playlist, fourthSong);
            playlist.Songs.Should().Contain(firstSong);
            playlist.Songs.Should().Contain(secondSong);
            playlist.Songs.Should().Contain(thirdSong);
            playlist.Songs.Should().NotContain(fourthSong);
        }


        [Fact(DisplayName = "Valid Playlist with Songs List")]
        public void AddSongsToPlaylist_NotValidPlaylistWithSongsList_ReturnFalse()
        {
            List<Song> songs = new List<Song>() { firstSong, secondSong, thirdSong };

            Playlist playlist = new Playlist() { MaxSongs = 7, Songs = new List<Song>()};

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(true);

             _sut.AddSongsToPlaylist(playlist, songs);

            _mockPlaylistValidationService.Received(3).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
            playlist.Songs.Should().Contain(firstSong);
            playlist.Songs.Should().Contain(secondSong);
            playlist.Songs.Should().Contain(thirdSong);
            playlist.Songs.Should().HaveCount(3);
        }
    }
}
