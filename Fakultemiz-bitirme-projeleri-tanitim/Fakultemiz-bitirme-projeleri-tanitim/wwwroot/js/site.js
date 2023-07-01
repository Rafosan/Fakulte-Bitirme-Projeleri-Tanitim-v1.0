//document.addEventListener('DOMContentLoaded', function () {
//    const projectHeartButton = document.getElementById('project-heart-button');

//    projectHeartButton.addEventListener('click', function () {
//        sendToggleLikeRequest();
//    });

//    function sendToggleLikeRequest() {
//        fetch('@Url.Action("ToggleLike", "Project")', {
//            method: 'POST',
//            headers: {
//                'Content-Type': 'application/json'
//            },
//            body: JSON.stringify({})
//        })
//            .then(function (response) {
//                if (response.ok) {
//                    return response.json();
//                } else {
//                    throw new Error('ToggleLike request failed.');
//                }
//            })
//            .then(function (data) {
//                console.log('Beğeni durumu güncellendi:', data);
//                // İşlem tamamlandıktan sonra gereken işlemleri burada yapabilirsiniz
//            })
//            .catch(function (error) {
//                console.error('Hata oluştu:', error);
//            });
//    }
//});
