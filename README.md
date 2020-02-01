# Array Helper (Unity / C#)


## What is it?
ArrayHelper is a Unity / C# helper class. It has a few useful generic static methods that can help you with common array operations. 

* Need to rotate piece data in a puzzle game? 

* Need to flip an array along x- or y-axis?

* Need to check if two arrays overlap?

* Need to convert a 1D array into a 2D array or vice versa?

All of these cases are handled with this helper class, in generic manner so you can operate on arrays of ints, string, char or whatever. 

Current limitation is the fact that overlap tests are carried out with a single value, so if there is a value 1 in x0, y0 and value 1 in another array's x0, y0 then there is a overlap - you cannot compare against a list of values (do values 1, 2, 3 overap 1).


# Methods

## ArrayOverlaps
This method takes two same size arrays and compares if specified values overlap in these arrays.

![ArrayOverlaps image](/doc/arrays_overlap.png)

## ArrayOverlapsAt
Similar to the ArrayOverlaps, but in this case instead of a bool, a List is returned with Vector2Int values of overlap locations.

![ArrayOverlaps image](/doc/arrays_overlap_at.png)


## ArraysOverlap
This method takes two arrays and compares where certain given value in second array overlaps the same value in the first array. Arrays don't need to be the same size, and second array can be offset so that it is partially not overlapping the first array.

![ArrayOverlaps image](/doc/array_overlaps_at.png)

## ArraysOverlapAt
Similar to the ArraysOverlap, but in this case instead of a bool, a List is returned with Vector2Int values of overlap locations.

![ArrayOverlaps image](/doc/array_overlaps.png)



## ToArr2D
Convert a 1D array into 2D array. Define width and height of the resulting array.

![ArrayOverlaps image](/doc/array1D_to_2D.png)


## ToArr1D
Convert a 2D array into 1D array.

![ArrayOverlaps image](/doc/array2D_to_array1D.png)


## RotateCWise
Rotate 2D array data 90 degrees clockwise. Returns a new array.

![ArrayOverlaps image](/doc/rotate_clockwise.png)


## RotateCCWise
Rotate 2D array data 90 degrees counterclockwise. Returns a new array.

![ArrayOverlaps image](/doc/rotate_counterclockwise.png)


## Rotate180
Rotate 2D array data 180 degrees. Returns a new array.

![ArrayOverlaps image](/doc/rotate_180.png)


## FlipX
Flips array data along x-axis. Returns a new array.

![ArrayOverlaps image](/doc/flip_horizontal.png)


## FlipY
Flips array data along y-axis. Returns a new array.

![ArrayOverlaps image](/doc/flip_vertical.png)


## About
I created Array Helper for myself for different personal Unity projects. These are pretty much work in progress.


## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
