(function () {
    'use strict';

    angular
        .module('contact.controllers', [])
        .controller('ContactController', ContactController)

    ContactController.$inject = ['contactFactory', '$scope'];

    function ContactController(contactFactory, $scope) {
        var vm = this;
        vm.contacts = [];

        $scope.getContacts = getContacts;
        $scope.saveContact = saveContact;

        //activate();

        //function activate() {
        //    getContacts();
        //}

        function getContacts() {
            return contactFactory.getContacts()
              .then(function (data) {
                  vm.contacts = data;
                  return vm.contacts;
              })
              .catch(function (data) {
                  $scope.errorgetcontacts = data;
              })
        }

        function saveContact(contact) {
            $scope.contact = {
                'contact': {
                    'Name': contact.Name,
                    'LastName': contact.LastName,
                    'Email': contact.Email,
                    'PhoneNumber': contact.PhoneNumber,
                    'CellPhoneNumber': contact.CellPhoneNumber
                }
            };

            contactFactory.saveContact($scope.contact)
                .then(function (data) {
                    alert("The contact was added!!");
                })
                .catch(function (data) {
                    $scope.errorcontact = data;
                });
        }
    }

})();