define(['todo-list/section'], function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (section){
            if (!(section instanceof Section)) {
                throw new TypeError('You must put section.');
            }

            this._sections.push(section);

            return this;
        };

        Container.prototype.getData = function (){
            var sections  = this._sections.map(function(item) {
                return item.getData();
            });

            return sections;
        };

        return Container;
    }());
    return Container;
});