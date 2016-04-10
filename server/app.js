"use strict";

var allTiles = [],
    tiles = [],
    matrix = [],
    size = 50,
    number = 0,
    limit = parseInt(size * size * 0.2, 10);

function getRandomInt(value)
{
    return parseInt(Math.random() * value, 10) + 1;
}

function tracePath(x1, x2, y1, y2)
{
    var temp;

    if (x1 > x2) {
      temp = x2;
      x2 = x1;
      x1 = temp;
    }

    if (y1 > y2) {
      temp = y2;
      y2 = y1;
      y1 = temp;
    }

    for (var i = x1; i <= x2; i++) {
      for (var j = y1; j <= y2; j++) {
        markPosition(i, j);
      }
    }
}

function markPosition(x, y)
{
  if (number <= limit) {
    if (typeof matrix[x] == "undefined") {
      matrix[x] = [];
    }
    if (typeof matrix[x][y] == "undefined") {
      matrix[x][y] = 1;
      var type = 0;
      var chance = parseInt(Math.random() * 100, 10);
      if (chance > 95) {
        type = 2;
      } else {
        if (chance > 80) {
          type = 1;
        }
      }
      tiles.push({"x": x, "y": y, "type": type});
      number++;
    }
  }
}

function renderPath(initialX, initialY)
{
    var steps = getRandomInt(3),
        branches = getRandomInt(3);

    var x = initialX, y = initialY;

    for (var i = 0; i < steps; i++) {

        var coordinate = getRandomInt(2) == 1,
            direction = getRandomInt(2) == 1;

        if (coordinate) {
          if (direction) {
            x++;
          } else {
            x--;
          }
        } else {
          if (direction) {
            y++;
          } else {
            y--;
          }
        }

        if (x < 0) {
          x = 0;
        }

        if (y < 0) {
          y = 0;
        }

        if (x > (size - 1)) {
          x = (size - 1);
        }

        if (y > (size - 1)) {
          y = (size - 1);
        }
    }

    tracePath(initialX, x, initialY, y);

    if (number <= limit)
      renderPath(x, y);
}

for (var i = 0; i < 100; i++) {
    tiles = [];
    matrix = [];
    number = 0;
    renderPath(25, 25);
    renderPath(25, 25);
    allTiles.push(tiles);
}

var express = require('express');
var app = express();

app.get('/', function (req, res) {
  res.send("Hello");
});

app.get('/get', function (req, res) {
  res.send(JSON.stringify(allTiles[parseInt(Math.random() * allTiles.length)]));
});

app.listen(3000, function () {
  console.log('Example app listening on port 3000!');
});
