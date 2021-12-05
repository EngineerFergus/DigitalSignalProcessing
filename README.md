# DigitalSignalProcessing
Implementation of many common Digital Signal Processing algorithms. The focus is on 1D signals with the potential for adding 2D data (such as images) later on. The accompanying WPF Showcase application is used for visualizing the performance of the algorithms. The [Live Charts Net](https://lvcharts.net/) toolbox is used for plotting data.

Sources:
- [The Scientist and Engineer's Guide to Digital Signal Processing](https://www.analog.com/en/education/education-library/scientist_engineers_guide.html#Foundations)
- [Optimizing 1D Convolution](https://stackoverflow.com/questions/7237907/1d-fast-convolution-without-fft)

Most of the algorithms will come from the textbook listed in the sources.

## 1D Convolution
The first major topic includes 1D convolution. The equation below shows how the 1D convolution between a signal x and a kernel h is calculated. With x having a length of N and h having a length of M, the output y will have a of L = N + M - 1. The sum runs from i = 0 to L - 1.

<p align="center">
    <img src="https://latex.codecogs.com/svg.latex?y[i]&space;=&space;\sum_{j&space;=&space;0}^{M&space;-&space;1}h[j]x[i-j]" title="y[i] = \sum_{j = 0}^{M - 1}h[j]x[i-j]" />
</p>

