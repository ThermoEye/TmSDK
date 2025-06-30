package kr.co.thermoeye.android;

import java.util.PriorityQueue;

public class CameraManager {
    // Maximum number of IDs that can be assigned to cameras
    private static final int MAX_ID_COUNT = 9;
    // PriorityQueue to store the available IDs. IDs will be automatically ordered in ascending order.
    private final PriorityQueue<Integer> availableIds = new PriorityQueue<Integer>();

    // Constructor initializes the available IDs (from 0 to MAX_ID_COUNT - 1) into the priority queue
    public CameraManager() {
        for (int i = 0; i < MAX_ID_COUNT; i++) {
            availableIds.add(i);
        }
    }

    // Method to get an available ID from the priority queue
    public Integer getAvailableID() {
        if (!availableIds.isEmpty()) {
            return availableIds.poll();
        }
        return null;
    }

    // Method to release an ID and add it back to the available IDs queue
    public void releaseId(int id) {
        if (id >= 0 && id < 9) {
            availableIds.offer(id);
        }
    }
}
