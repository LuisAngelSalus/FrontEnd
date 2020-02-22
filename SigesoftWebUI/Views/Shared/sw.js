//const CACHE_STATIC_NAME = "static-v2";
//self.addEventListener("install", e => {
//    const cacheProm = caches.open(CACHE_STATIC_NAME).then(cache => {
//        return cache.addAll([
//            "/",
//            "/sw.js"           
//        ]);
//    });    
    
//    e.waitUntil(Promise.all([cacheProm]));
//});
//self.addEventListener("push", e => {
//    console.log(JSON.parse(e.data.text()));

//    const data = JSON.parse(e.data.text());
//    const options = {
//        body: data.message,
//        icon: "Resources/css/img/logo.png",
//        badge: "images/favicon.ico",
//        data: {
//            url: "http://beto1826-001-site4.etempurl.com/"
//        }
//    };

//    e.waitUntil(self.registration.showNotification(data.title, options));
//});