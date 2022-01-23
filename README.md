# DigitalSignalProcessing
Implementation of many common Digital Signal Processing algorithms. The focus is on 1D signals with the potential for adding 2D data (such as images) later on. The accompanying WPF Showcase application is used for visualizing the performance of the algorithms. The [OxyPlot](https://github.com/oxyplot/oxyplot) toolbox is used for plotting data.

Sources:
- [The Scientist and Engineer's Guide to Digital Signal Processing](https://www.analog.com/en/education/education-library/scientist_engineers_guide.html#Foundations)
- [Optimizing 1D Convolution](https://stackoverflow.com/questions/7237907/1d-fast-convolution-without-fft)
- [Discrete Fourier Transform](https://en.wikipedia.org/wiki/Discrete_Fourier_transform)
- [Cooley-Tukey Fast Fourier Transform](https://en.wikipedia.org/wiki/Cooley%E2%80%93Tukey_FFT_algorithm)
- [Calculating inverse FFT from forward FFT](https://flylib.com/books/en/2.729.1/computing_the_inverse_fft_using_the_forward_fft.html)
- [Enumeration to ComboBox Options](https://stackoverflow.com/questions/6145888/how-to-bind-an-enum-to-a-combobox-control-in-wpf)

Most of the algorithms will come from the textbook listed in the sources.

## 1D Convolution
The first major topic includes 1D convolution. The equation below shows how the 1D convolution between a signal x and a kernel h is calculated. With x having a length of N and h having a length of M, the output y will have a length of L = N + M - 1.

<p align="center">
    <img src="https://latex.codecogs.com/svg.latex?y[i]&space;=&space;\sum_{j=0}^{M-1}h[j]x[i-j]" title="y[i] = \sum_{j=0}^{M-1}h[j]x[i-j]" />
</p>

The values for i range from 0 to L - 1. A quick glance at this algorithm will show that, if not properly implemented, out of bounds exceptions can occur while trying to calculate the first and last M - 1 points in y. During a naive implementation of this algorithm, the index for x must be checked for every iteration of i to account for these boundary conditions. To avoid checking the indexing of x, the for loop for calculating the convolution can be split into three separate loops. These loops are shown below in the updated equations for y.

<p align="center">
    <img src="https://latex.codecogs.com/svg.latex?y[i]&space;=&space;\begin{cases}&space;&&space;\text{&space;if&space;}&space;0&space;\leq&space;i<&space;M-1&space;\text{&space;,&space;}\sum_{j=0}^{i}h[j]x[i-j]\\&space;&&space;\text{&space;if&space;}&space;M-1\leq&space;i<&space;L-M&plus;1\text{&space;,&space;}&space;\sum_{j=0}^{M-1}h[j]x[i-j]&space;\\&space;&&space;\text{&space;if&space;}&space;L-M&plus;1\leq&space;i<L\text{&space;,&space;}\sum_{j=i-L&plus;M}^{M-1}h[j]x[i-j]&space;\end{cases}" title="y[i] = \begin{cases} & \text{ if } 0 \leq i< M-1 \text{ , }\sum_{j=0}^{i}h[j]x[i-j]\\ & \text{ if } M-1\leq i< L-M+1\text{ , } \sum_{j=0}^{M-1}h[j]x[i-j] \\ & \text{ if } L-M+1\leq i<L\text{ , }\sum_{j=i-L+M}^{M-1}h[j]x[i-j] \end{cases}" />
</p>

## Common Sequences

## Common Windows

## Discrete Fourier Transform (DFT)

## Fast Fourier Transform (FFT)

## Finite Impulse Response (FIR) Filters

## Infinite Impulse Response (IIR) Filters
