﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using GabriEShopAPI.Exceptions;

namespace GabriEShopAPI.Controllers 
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Get all items
        /// </summary>
        [HttpGet]
        [Route("items")]
        public ActionResult<List<Item>> GetAll()
        {
            return Ok( _itemService.GetAll().ToList());
        }

        /// <summary>
        /// Get item by id
        /// </summary>
        [HttpGet]
        [Route("item/{id}")]
        public async Task<ActionResult<Item>> GetIById(int id)
        {
             return Ok(await _itemService.GetById(id));
        }

        /// <summary>
        /// Add new item
        /// </summary>
        [HttpPost]
        [Route("add/item")]
        public async Task<IActionResult> Add(AddItem newItem)
        {
            var result = await _itemService.Add(newItem);
            return CreatedAtAction(nameof(GetIById), new { id = result.id }, newItem);
            //pabaigoj return newItem, kad grazintu tai, ka raso useris. result - is duombazes
        }

        /// <summary>
        /// Update existing item
        /// </summary>
        [HttpPut]
        [Route("update/item/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateItem updateItem)
        {
            var result = await _itemService.Update(id, updateItem.Name, updateItem.Price, updateItem.Quantity);
            return Ok(result);
        }

        /// <summary>
        /// Delete existing item
        /// </summary>
        [HttpDelete]
        [Route("delete/item/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemService.Delete(id);
            return Ok("Item quantity reduced successfully.");
        }
    }
}

