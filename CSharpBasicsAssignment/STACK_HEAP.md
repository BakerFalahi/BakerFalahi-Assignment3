# Stack & Heap --- Order Reference Type

This file illustrates the stack and heap behavior for the exact sequence
required in Part E:

``` csharp
Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };
Order o2 = o1;
o2.IsPaid = true;
```

## Diagram 1 --- After `Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };`

``` text
STACK                          HEAP

┌───────────────┐             ┌───────────────────────────┐
│ o1            │────────────▶│ Order object              │
│ reference     │             │                           │
└───────────────┘             │ OrderId = 1               │
                              │ CustomerName = "Ali"      │
                              │ Quantity = 0              │
                              │ UnitPrice = 0             │
                              │ TotalPrice = 0            │
                              │ IsPaid = false            │
                              │ DiscountPercent = 0       │
                              │ ShippingCity = ""         │
                              │ Priority = '\0'           │
                              │ ItemCode = 0              │
                              └───────────────────────────┘
```

`o1` holds a reference to one `Order` object on the heap.

## Diagram 2 --- After `Order o2 = o1;`

``` text
STACK                          HEAP

┌───────────────┐
│ o1            │──────────────┐
│ reference     │              │
└───────────────┘              │
                               ▼
                         ┌───────────────────────────┐
┌───────────────┐        │ Order object              │
│ o2            │────────▶                           │
│ reference     │        │ OrderId = 1               │
└───────────────┘        │ CustomerName = "Ali"      │
                         │ Quantity = 0              │
                         │ UnitPrice = 0             │
                         │ TotalPrice = 0            │
                         │ IsPaid = false            │
                         │ DiscountPercent = 0       │
                         │ ShippingCity = ""         │
                         │ Priority = '\0'           │
                         │ ItemCode = 0              │
                         └───────────────────────────┘
```

Assigning `o1` to `o2` copies the reference, not the `Order` object, so
both variables point to the same heap object.

## Diagram 3 --- After `o2.IsPaid = true;`

``` text
STACK                          HEAP

┌───────────────┐
│ o1            │──────────────┐
│ reference     │              │
└───────────────┘              │
                               ▼
                         ┌───────────────────────────┐
┌───────────────┐        │ Order object              │
│ o2            │────────▶                           │
│ reference     │        │ OrderId = 1               │
└───────────────┘        │ CustomerName = "Ali"      │
                         │ Quantity = 0              │
                         │ UnitPrice = 0             │
                         │ TotalPrice = 0            │
                         │ IsPaid = true             │
                         │ DiscountPercent = 0       │
                         │ ShippingCity = ""         │
                         │ Priority = '\0'           │
                         │ ItemCode = 0              │
                         └───────────────────────────┘
```

Changing `o2.IsPaid` updates the single shared `Order` object. Both `o1`
and `o2` still point to that same object.

## What would be different with structs?

If `Order` were a `struct` instead of a `class`, assigning `o1` to `o2`
would copy the entire value instead of copying a reference. The two
variables would then contain independent values. Changing `o2.IsPaid`
would only change the copy stored in `o2`; `o1.IsPaid` would remain
unchanged.

Using the `Point` struct from Part C, the same idea looks like this:

``` text
After: Point p2 = p1;

STACK

┌──────────────────────┐
│ p1                   │
│ X = 1                │
│ Y = 2                │
└──────────────────────┘

┌──────────────────────┐
│ p2                   │
│ X = 1                │
│ Y = 2                │
└──────────────────────┘

After: p2.X = 99;

STACK

┌──────────────────────┐
│ p1                   │
│ X = 1                │
│ Y = 2                │
└──────────────────────┘

┌──────────────────────┐
│ p2                   │
│ X = 99               │
│ Y = 2                │
└──────────────────────┘
```

`p1` and `p2` are independent values because `Point` is a value type.
