﻿using Microsoft.AspNetCore.Mvc;
using nzwalks.API.Data;
using nzwalks.Models.Domain;
using nzwalks.Models.DTO;
using System.Reflection.Metadata.Ecma335;

namespace nzwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly NZWalksDbContext dbContext;
        public RegionController(NZWalksDbContext dbcontext)
        {
            this.dbContext= dbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions= dbContext.Regions.ToList();
            var regionDto = new List<regiondto>();
            foreach(var region in  regions)
            {
                regionDto.Add(new regiondto()
                {
                    Id= region.Id,
                    Name=region.Name,
                    Code=region.Code,
                    RegionImageUrl=region.RegionImageUrl,
                });

            }
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetByID([FromRoute]Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            else
            {
                var regiondto = new regiondto{
                    Id= region.Id,
                    Code=region.Code,
                   Name=region.Name,
                   RegionImageUrl=region.RegionImageUrl,
                };

                return Ok(region);
            }
        }

        [HttpPost]

        public IActionResult create([FromBody]AddRegionRequestDto AddRegionRequestDto)
        {
            var regionModel = new Region
            {
                Code = AddRegionRequestDto.Code,
                Name = AddRegionRequestDto.Name,
                RegionImageUrl = AddRegionRequestDto.RegionImageUrl,
            };
            dbContext.Regions.Add(regionModel);
            dbContext.SaveChanges();

            var regionDto = new regiondto
            {
                Id = regionModel.Id,
                Code = regionModel.Code,
                Name = regionModel.Name,
                RegionImageUrl = regionModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetByID),new { regionDto.Id}, regionDto);

        }

    }
}
