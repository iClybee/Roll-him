mergeInto(LibraryManager.library, {

  ShowFullscreen: function () {
      ysdk.adv.showFullscreenAdv({
      callbacks: {
          onOpen: function(wasShown) {
            console.log('������� Fullscreen ���������.');
          },
          onClose: function(wasShown) {
            console.log("������� Fullscreen ���������.");
          },
          onError: function(error) {
            console.log("������ �� ������� Fullscreen.");
          }
      }
      })
  },
});