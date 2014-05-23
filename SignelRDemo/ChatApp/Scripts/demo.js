(function() {
	var demoHub = $.connection.demoHub;
	$.connection.hub.logging = true;
	$.connection.hub.start();

	demoHub.client.newMessage = function(message) {
		// get it on to the client screen
		model.addMessage(message);
	};

	var Model = function() {
		var self = this;
		self.message = ko.observable(""),
			self.messages = ko.observableArray();
	};

	Model.prototype = {
		sendMessage: function() {
			var self = this;
			demoHub.server.send(self.message());
			self.message("");
		},

		addMessage: function(message) {
			var self = this;
			self.messages.push(message);
		}
	};

	var model = new Model();
	$(function() {
		ko.applyBindings(model);
	});

}());