'use strict';

define(
    [
        'app',
        'Cells/NzbDroneCell',
        'Commands/CommandController'
    ], function (App, NzbDroneCell, CommandController) {
        return NzbDroneCell.extend({

            className: 'episode-actions-cell',
            template : 'Cells/EpisodeActionsCellTemplate',

            ui: {
                automaticSearch: '.x-automatic-search-icon'
            },

            events: {
                'click .x-automatic-search': '_automaticSearch',
                'click .x-manual-search'   : '_manualSearch'
            },

            render: function () {
                var templateName = this.column.get('template') || this.template;

                this.templateFunction = Marionette.TemplateCache.get(templateName);
                var data = this.cellValue.toJSON();
                var html = this.templateFunction(data);
                this.$el.html(html);

                CommandController.bindToCommand({
                    element: this.$(this.ui.automaticSearch),
                    command: {
                        name        : 'episodeSearch',
                        episodeId: this.model.get('id')
                    }
                });

                this.delegateEvents();
                return this;
            },

            _automaticSearch: function () {
                CommandController.Execute('episodeSearch', {
                    name        : 'episodeSearch',
                    episodeId: this.model.get('id')
                });
            },

            _manualSearch: function () {
                App.vent.trigger(App.Commands.ShowEpisodeDetails, { episode: this.cellValue, hideSeriesLink: true, openingTab: 'search' });
            }
        });
    });
