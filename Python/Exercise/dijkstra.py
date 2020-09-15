# 迪克斯特拉算法： 计算加权图中的最短路径
# graph: 起点start，a,b,终点fin之间的距离
graph = {}
graph["s"] = {}
graph["s"]["a"] = 5
graph["s"]["b"] = 3
graph["s"]["c"] = 2
graph["s"]["d"] = 4
graph["a"] = {}
graph["a"]["e"] = 3
graph["b"] = {}
graph["b"]["a"] = 2
graph["b"]["f"] = 1
graph["c"] = {}
graph["c"]["f"] = 4
graph["c"]["h"] = 8
graph["d"] = {}
graph["d"]["c"] = 1
graph["d"]["h"] = 6
graph["e"] = {}
graph["e"]["g"] = 1
graph["f"] = {}
graph["f"]["e"] = 1
graph["f"]["h"] = 2
graph["h"] = {}
graph["h"]["g"] = 4
graph["g"] = {}
# costs: 起点到 a,b,fin的开销
infinity = float("inf")
costs = {}
costs["a"] = 5
costs["b"] = 3
costs["c"] = 2
costs["d"] = 4
costs["e"] = infinity
costs["f"] = infinity
costs["g"] = infinity
costs["h"] = infinity
# processed: 记录处理过的节点，避免重复处理
processed = []


# find_lowest_cost_node(costs): 返回开销最低的点
def find_lowest_cost_node(costs):
    lowest_cost = float("inf")
    lowest_cost_node = None
    for node in costs:
        cost = costs[node]
        if cost < lowest_cost and node not in processed:
            lowest_cost = cost
            lowest_cost_node = node
    return lowest_cost_node


# Dijkstra implement
node = find_lowest_cost_node(costs)
while node is not None:
    cost = costs[node]
    neighbors = graph[node]
    for n in neighbors.keys():
        new_cost = cost + neighbors[n]
        if costs[n] > new_cost:
            costs[n] = new_cost
    processed.append(node)
    node = find_lowest_cost_node(costs)

print(processed)
print(costs)

# infinity = float("inf")
# matrix = [
#     [0, 5, 3, 2, 4, infinity, infinity, infinity, infinity],
#     [5, 0, ]
#     ]
