cmake_minimum_required(VERSION 3.20)
project(PointRenderer)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED True)

# Add include directories
include_directories(${CMAKE_SOURCE_DIR}/include)

# Add library directories
link_directories(${CMAKE_SOURCE_DIR}/lib)

# Find required packages
find_package(OpenGL REQUIRED)

# Add source files
set(SOURCES
    src/pointRenderer.cpp
    src/pointRenderer.vs
    src/pointRenderer.fs
    src/glad.c
)

# Create the executable
add_executable(PointRenderer ${SOURCES})

# Link libraries
target_link_libraries(PointRenderer
    OpenGL::GL
    glfw3
)

configure_file(${CMAKE_SOURCE_DIR}/src/saurier-normal-small.pts ${CMAKE_BINARY_DIR}/saurier-normal-small.pts COPYONLY)
configure_file(${CMAKE_SOURCE_DIR}/src/pointRenderer.vs ${CMAKE_BINARY_DIR}/pointRenderer.vs COPYONLY)
configure_file(${CMAKE_SOURCE_DIR}/src/pointRenderer.fs ${CMAKE_BINARY_DIR}/pointRenderer.fs COPYONLY)