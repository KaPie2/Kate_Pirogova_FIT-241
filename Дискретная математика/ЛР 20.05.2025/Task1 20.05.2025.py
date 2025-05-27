#Форд-Фалкерсон

import heapq

def find_components(n, data, vertexes, matrix):
    if n not in data:
        data.append(n)
        if n in vertexes:
            vertexes.remove(n)
        for i in range(len(matrix)):
            if matrix[n][i] > 0 and i not in data:
                find_components(i, data, vertexes, matrix)

def find_path(matrix):
    heap = [(-matrix[0][i], 0, i) for i in range(len(matrix)) if matrix[0][i] > 0]
    heapq.heapify(heap)
    visited = [False] * len(matrix)
    visited[0] = True
    parent = [-1] * len(matrix)

    while heap:
        capacity, u, v = heapq.heappop(heap)
        capacity = -capacity
        if visited[v]:
            continue
        visited[v] = True
        parent[v] = u
        if v == len(matrix) - 1:
            path = []
            current = v
            while current != -1:
                path.append(current)
                current = parent[current]
            return path[::-1]
        for neighbor in range(len(matrix)):
            if matrix[v][neighbor] > 0 and not visited[neighbor]:
                new_capacity = min(capacity, matrix[v][neighbor])
                heapq.heappush(heap, (-new_capacity, v, neighbor))
    return None

def ford_fulkerson(matrix):
    max_flow = 0
    original_matrix = [row[:] for row in matrix]
    while True:
        path = find_path(matrix)
        if not path:
            break
        path_flow = min(matrix[path[i]][path[i + 1]] for i in range(len(path) - 1))
        max_flow += path_flow
        for i in range(len(path) - 1):
            u, v = path[i], path[i + 1]
            matrix[u][v] -= path_flow
            matrix[v][u] += path_flow

        vertexes = list(range(len(matrix)))
        components = []
        while vertexes:
            data = []
            find_components(vertexes[0], data, vertexes, matrix)
            components.append(data)
            if len(components) > 1:
                break
    return max_flow

with open('test1.txt') as f:
    matrix = [list(map(int, line.split())) for line in f]

max_flow = ford_fulkerson(matrix)
print(f"Максимальный поток: {max_flow}")
