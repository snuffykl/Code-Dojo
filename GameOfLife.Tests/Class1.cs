using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void Grid_CallingTheConstructor_ShouldBeAbleToCreateInstanceOfGridClass()
        {
            var grid = new Grid();
            grid.Should().NotBeNull();
        }

        [Test]
        public void AddCell_WhenIAddCellToASepcificLocation_ItShouldBeAdded()
        {
            // I want to add cells to grid
            var grid = new Grid();
            var XCordinate = 10;
            var YCordinate = 2;

            grid.AddCell(new Cell(), XCordinate, YCordinate);

            var existingCell = grid.GetCellAtLocation(XCordinate, YCordinate);

            existingCell.Should().NotBeNull();
        }

        [Test]
        public void GetNeighbours_WhenITryToGetNeighboursOfASpecificCell_IShouldGetAll8NeighbouringCells()
        {

            var grid = new Grid();
            grid.AddCell(new Cell(), 8, 1);
            grid.AddCell(new Cell(), 9, 1);
            grid.AddCell(new Cell(), 10, 1 );
            
            grid.AddCell(new Cell(), 8, 2);
            grid.AddCell(new Cell(), 9, 2);
            grid.AddCell(new Cell(), 10, 2);

            grid.AddCell(new Cell(), 8, 3);
            grid.AddCell(new Cell(), 9, 3);
            grid.AddCell(new Cell(), 10, 3);

            var targetXCoordinate = 9;
            var targetYCoordinate = 2;

            var neighbours = grid.GetNeighbours(targetXCoordinate, targetYCoordinate);

            neighbours.Count.Should().Equals(8);
        }
    }

    public class Cell
    {
    }

    public class Grid
    {
        private List<CellContainer> _cellContainers;
        public Grid()
        {
            _cellContainers = new List<CellContainer>();
        }
        
        public void AddCell(Cell cell, int xCordinate, int yCordinate)
        {
            _cellContainers.Add(new CellContainer{Cell = cell, XCoordinate = xCordinate,YCoordinate = yCordinate});
        }

        public CellContainer GetCellAtLocation(int xCordinate, int yCordinate)
        {
            return _cellContainers.Where(x => x.XCoordinate == xCordinate && x.YCoordinate == yCordinate).FirstOrDefault();
        }

        public List<CellContainer> GetNeighbours(int targetXCoordinate, int targetYCoordinate)
        {
            var leftNeighbour = GetCellAtLocation(targetXCoordinate - 1, targetYCoordinate);
            var rightNeighbour = GetCellAtLocation(targetXCoordinate + 1, targetYCoordinate);
            var topNeighbour = GetCellAtLocation(targetXCoordinate , targetYCoordinate -1);
            var bottomNeighbour = GetCellAtLocation(targetXCoordinate, targetYCoordinate + 1);

            var topleftNeighbour = GetCellAtLocation(targetXCoordinate - 1, targetYCoordinate - 1);
            var toprightNeighbour = GetCellAtLocation(targetXCoordinate + 1, targetYCoordinate -1);
            var bottomtopNeighbour = GetCellAtLocation(targetXCoordinate - 1, targetYCoordinate + 1);
            var bottomrightNeighbour = GetCellAtLocation(targetXCoordinate + 1, targetYCoordinate - 1);

            return _cellContainers;
        }
    }

    public class CellContainer
    {
        public Cell Cell { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }
    }
}

    
