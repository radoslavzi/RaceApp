var uiParser = (function () {
    function Parser(url) {
        this.url = url;
    }

    Parser.prototype = {
        getData: function (url) {
            debugger
            var url = url;
            var self = this;
            $.get(url, function (data) {
                
                self.renderUI(JSON.parse(data.Data));
            });
        },
        renderUI: function (data) {
            var div = '';
            for (var i in data) {
                div += "<div class='event'><div>Race Event Object</div>" +
                "<div>Id: " + data[i].RaceEvent.Id + "</div>" +
                "<div>EventNumber: " + data[i].RaceEvent.EventNumber + "</div>" +
                "<div>FinishTime: " + data[i].RaceEvent.FinishTime + "</div>" +
                "<div>Distance: " + data[i].RaceEvent.Distance + "</div>" +
                 "<div>Name: " + data[i].RaceEvent.Name + "</div>";
                
                var entries = data[i].RaceEventEntries;
                div +="<div class='entire-events'>"
                for (var j in entries) {
                    div+="<div class='entire-event'>"
                    div += "<div>Id: " + entries[j].Id + "</div>" +
                         "<div>Name: " + entries[j].Name + "</div>" +
                          "<div>OddsDecimal: " + entries[j].OddsDecimal + "</div>";
                    div += '</div>';
                }
                div += "</div></div>";

                $('#parse-data').append(div);
            }
            this.listeners();
        },
        listeners: function () {
            var self = this;
            $('#sort-asc').click(function (ev) {
                ev.preventDefault();
                $('#parse-data').html('');
                self.getData('/api/parse/get?isAsc=' + true);
            })

            $('#sort-desc').click(function (ev) {
                ev.preventDefault();
                $('#parse-data').html('');
                self.getData('/api/parse/get?isDesc=' + true);
            })
        }
    }

    return {
        getParser: function (url) {
            return new Parser(url);
        }
    }
})();

var parser = uiParser.getParser('/api/parse');
parser.getData('/api/parse');