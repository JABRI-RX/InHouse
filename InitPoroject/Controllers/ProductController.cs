using InitPoroject.Dto;
using InitPoroject.Dto.product;
using InitPoroject.Helpers;
using InitPoroject.Interface;
using InitPoroject.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InitPoroject.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct([FromQuery] QueryObjectProuct queryObject)
    {
        await Task.Delay(500);
        var products = await _productRepository.GetAllProductsAsync(queryObject); 
        return  Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var product = await _productRepository.GetProductById(id);
        if (product is null)
            return NotFound();
        return Ok(product);
    }
    [HttpGet("{name}")]
    public async Task<IActionResult> GetProductByName([FromRoute] string name)
    {
        var product = await _productRepository.GetProductsByName(name);
        if (product is null)
            return NotFound();
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var product = await _productRepository.AddProductAsync(productDto.ToProduct());
        return CreatedAtAction(nameof(GetProductById),
            new { id = product.Id },
            product.ToReadProduct()
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id,[FromBody] UpdateProductDto productDto )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var product = await _productRepository.UpdateProduct(id, productDto.ToProduct());
        if (product is null)
            return NotFound();
        return CreatedAtAction(
            nameof(GetProductById),
            new {id=product.Id},
            productDto.ToProduct()
        );
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        var product = await _productRepository.DeleteProductById(id);
        if (!product)
            return NotFound();
        return NoContent();
    }
}