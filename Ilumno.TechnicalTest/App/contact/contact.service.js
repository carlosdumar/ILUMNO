(function () {
    'use strict';

    angular
     .module('contact.services', [])
     .factory('contactFactory', contactFactory);

    contactFactory.$inject = ['$http', '$q', '$rootScope'];

    function contactFactory($http, $q, $rootScope) {
        return {
            getContacts: getContacts,
            saveContact: saveContact
        };

        function getContacts() {
            var defered = $q.defer();

            $http.get('/api/contacts')
                .then(getContactsComplete)
                .catch(getContactsFailed);

            function getContactsComplete(response) {
                if (response.status == 200) {
                    defered.resolve(response.data);
                }
                else {
                    defered.reject(response.data);
                }
            }
            function getContactsFailed(response) {
                var errorMessage = "The request failed with response: " + response.data.error.message + "and status code: " + response.status;
                defered.reject(errorMessage);
            }
            return defered.promise;
        }

        function saveContact(contact) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: '/api/contacts/',
                data: contact,
                headers:
                    {
                        'Accept': 'application/json, application/xml, text/play, text/html, *.*',
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
            })
            .then(saveContactComplete)
            .catch(saveContactFailed);

            function saveContactComplete(response) {
                if (response.status == 200) {
                    defered.resolve(response.data);
                } else {
                    defered.reject(response.data);
                }
            }
            function saveContactFailed(data, status) {

                return $q.reject("The request failed with reponse " + response.data.error.message + "and status code: " + response.status);
            }

            return defered.promise;
        }
    }

})();